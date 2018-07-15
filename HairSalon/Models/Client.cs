using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
        public int StylistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }

        public Client(int stylistId, string firstName, string lastName, string phoneNumber, string email, string notes, int id = 0)
        {
            StylistId = stylistId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
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
                bool firstNameEquality = (this.FirstName == newClient.FirstName);
                bool lastNameEquality = (this.LastName == newClient.LastName);
                bool phoneNumberEquality = (this.PhoneNumber == newClient.PhoneNumber);
                bool emailEquality = (this.Email == newClient.Email);
                bool notesEquality = (this.Notes == newClient.Notes);
                bool idEquality = (this.Id == newClient.Id);

                return (stylistIdEquality && firstNameEquality && lastNameEquality && phoneNumberEquality && emailEquality && notesEquality && idEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> {};

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients ORDER BY last_name;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                int stylistId = rdr.GetInt32(1);
                string clientFirstName = rdr.GetString(2);
                string clientLastName = rdr.GetString(3);
                string clientPhoneNumber = rdr.GetString(4);
                string clientEmail = rdr.GetString(5);
                string clientNotes = rdr.GetString(6);
                Client newClient = new Client(stylistId, clientFirstName, clientLastName, clientPhoneNumber, clientEmail, clientNotes, clientId);
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
            cmd.CommandText = @"INSERT INTO clients (stylist_id, first_name, last_name, phone_number, email, notes) VALUES (@stylistID, @clientFirstName, @clientLastName, @clientPhoneNumber, @clientEmail, @clientNotes);";
            cmd.Parameters.AddWithValue("@stylistId", this.StylistId);
            cmd.Parameters.AddWithValue("@clientFirstName", this.FirstName);
            cmd.Parameters.AddWithValue("@clientLastName", this.LastName);
            cmd.Parameters.AddWithValue("@clientPhoneNumber", this.PhoneNumber);
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
            string clientFirstName = "";
            string clientLastName = "";
            string clientPhoneNumber = "";
            string clientEmail = "";
            string clientNotes = "";

            while (rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                stylistId = rdr.GetInt32(1);
                clientFirstName = rdr.GetString(2);
                clientLastName = rdr.GetString(3);
                clientPhoneNumber = rdr.GetString(4);
                clientEmail = rdr.GetString(5);
                clientNotes = rdr.GetString(6);
            }

            Client foundClient = new Client (stylistId, clientFirstName, clientLastName, clientPhoneNumber, clientEmail, clientNotes, clientId);

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

        public void Update(int stylistId, string firstName, string lastName, string phoneNumber, string email, string notes)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = @stylistId, first_name = @clientFirstName, last_name = @clientLastName, phone_number = @clientPhoneNumber, email = @clientEmail, notes = @clientNotes WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@stylistId", stylistId);
            cmd.Parameters.AddWithValue("@clientFirstName", firstName);
            cmd.Parameters.AddWithValue("@clientLastName", lastName);
            cmd.Parameters.AddWithValue("@clientPhoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@clientEmail", email);
            cmd.Parameters.AddWithValue("@clientNotes", notes);
            cmd.Parameters.AddWithValue("@clientId", this.Id);
            cmd.ExecuteNonQuery();

            StylistId = stylistId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAllStylists()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists ORDER BY last_name;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistFirstName = rdr.GetString(1);
                string stylistLastName = rdr.GetString(2);
                string stylistPhoneNumber = rdr.GetString(3);
                string stylistEmail = rdr.GetString(4);
                string stylistStreet = rdr.GetString(5);
                string stylistCity = rdr.GetString(6);
                string stylistState = rdr.GetString(7);
                string stylistZip = rdr.GetString(8);
                DateTime stylistStartDate = rdr.GetDateTime(9);
                Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);
                allStylists.Add(newStylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }
    }
}