using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
        public int StylistId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }

        public Client(int stylistId, string name, string email, string notes, int id = 0)
        {
            StylistId = stylistId;
            Name = name;
            Email = email;
            Notes = notes;
            Id = id;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;

                bool stylistIdEquality = (this.StylistId == newClient.StylistId);
                bool nameEquality = (this.Name == newClient.Name);
                bool emailEquality = (this.Email == newClient.Email);
                bool notesEquality = (this.Notes == newClient.Notes);
                bool idEquality = (this.Id == newClient.Id);

                return (stylistIdEquality && nameEquality && emailEquality && notesEquality && idEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> {};

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                int stylistId = rdr.GetInt32(1);
                string clientName = rdr.GetString(2);
                string clientEmail = rdr.GetString(3);
                string clientNotes = rdr.GetString(4);
                Client newClient = new Client(stylistId, clientName, clientEmail, clientNotes, clientId);
                allClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allClients;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (stylist_id, name, email, notes) VALUES (@stylistID, @clientName, @clientEmail, @clientNotes);";
            cmd.Parameters.AddWithValue("@stylistId", this.StylistId);
            cmd.Parameters.AddWithValue("@clientName", this.Name);
            cmd.Parameters.AddWithValue("@clientEmail", this.Email);
            cmd.Parameters.AddWithValue("@clientNotes", this.Notes);
            cmd.ExecuteNonQuery();

            Id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@clientId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            
            int clientId = 0;
            int stylistId = 0;
            string clientName = "";
            string clientEmail = "";
            string clientNotes = "";

            while (rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                stylistId = rdr.GetInt32(1);
                clientName = rdr.GetString(2);
                clientEmail = rdr.GetString(3);
                clientNotes = rdr.GetString(4);
            }

            Client foundClient = new Client (stylistId, clientName, clientEmail, clientNotes, clientId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            
            return foundClient;
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@clientId", id);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Update(int stylistId, string name, string email, string notes)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = @stylistId, name = @clientName, email = @clientEmail, notes = @clientNotes WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@stylistId", stylistId);
            cmd.Parameters.AddWithValue("@clientName", name);
            cmd.Parameters.AddWithValue("@clientEmail", email);
            cmd.Parameters.AddWithValue("@clientNotes", notes);
            cmd.Parameters.AddWithValue("@clientId", this.Id);
            cmd.ExecuteNonQuery();

            StylistId = stylistId;
            Name = name;
            Email = email;
            Notes = notes;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}