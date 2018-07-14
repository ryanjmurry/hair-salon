using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime StartDate { get; set; }
        public int Id { get; set; }

        public Stylist(string firstName, string lastName, string email, string street, string city, string state, string zip, DateTime startDate, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            StartDate = startDate;
            Id = id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                
                bool firstNameEquality = (this.FirstName == newStylist.FirstName);
                bool lastNameEquality = (this.LastName == newStylist.LastName);
                bool emailEquality = (this.Email == newStylist.Email);
                bool streetEquality = (this.Street == newStylist.Street);
                bool cityEquality = (this.City == newStylist.City);
                bool stateEquality = (this.State == newStylist.State);
                bool zipEquality = (this.Zip == newStylist.Zip);
                bool dateEquality = (this.StartDate == newStylist.StartDate);
                bool idEquality = (this.Id == newStylist.Id);
                
                return (firstNameEquality && lastNameEquality && emailEquality && streetEquality && cityEquality && stateEquality && zipEquality && dateEquality && idEquality);
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistFirstName = rdr.GetString(1);
                string stylistLastName = rdr.GetString(2);
                string stylistEmail = rdr.GetString(3);
                string stylistStreet = rdr.GetString(4);
                string stylistCity = rdr.GetString(5);
                string stylistState = rdr.GetString(6);
                string stylistZip = rdr.GetString(7);
                DateTime stylistStartDate = rdr.GetDateTime(8);
                Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);
                allStylists.Add(newStylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (first_name, last_name, email, street, city, state, zip, start_date) VALUES (@stylistFirstName, @stylistLastName, @stylistEmail, @stylistStreet, @stylistCity, @stylistState, @stylistZip, @stylistStartDate);";

            cmd.Parameters.AddWithValue("@stylistFirstName", this.FirstName);
            cmd.Parameters.AddWithValue("@stylistLastName", this.LastName);
            cmd.Parameters.AddWithValue("@stylistEmail", this.Email);
            cmd.Parameters.AddWithValue("@stylistStreet", this.Street);
            cmd.Parameters.AddWithValue("@stylistCity", this.City);
            cmd.Parameters.AddWithValue("@stylistState", this.State);
            cmd.Parameters.AddWithValue("@stylistZip", this.Zip);
            cmd.Parameters.AddWithValue("@stylistStartDate", this.StartDate);
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
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        
                int stylistId = 0;
                string stylistFirstName = "";
                string stylistLastName = "";
                string stylistEmail = "";
                string stylistStreet = "";
                string stylistCity = "";
                string stylistState = "";
                string stylistZip = "";
                DateTime stylistStartDate = new DateTime(); 

            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistFirstName = rdr.GetString(1);
                stylistLastName = rdr.GetString(2);
                stylistEmail = rdr.GetString(3);
                stylistStreet = rdr.GetString(4);
                stylistCity = rdr.GetString(5);
                stylistState = rdr.GetString(6);
                stylistZip = rdr.GetString(7);
                stylistStartDate = rdr.GetDateTime(8);
            }

            Stylist foundStylist = new Stylist(stylistFirstName, stylistLastName, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Close();
            }

            return foundStylist;
        }

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", id);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Update(string firstName, string lastName, string email, string street, string city, string state, string zip, DateTime startDate)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET first_name = @stylistFirstName, last_name = @stylistLastName, email = @stylistEmail, street = @stylistStreet, city = @stylistCity, state = @stylistState, zip = @stylistZip, start_date = @stylistStartDate WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistFirstName", firstName);
            cmd.Parameters.AddWithValue("@stylistLastName", lastName);
            cmd.Parameters.AddWithValue("@stylistEmail", email);
            cmd.Parameters.AddWithValue("@stylistStreet", street);
            cmd.Parameters.AddWithValue("@stylistCity", city);
            cmd.Parameters.AddWithValue("@stylistState", state);
            cmd.Parameters.AddWithValue("@stylistZip", zip);
            cmd.Parameters.AddWithValue("@stylistStartDate", startDate);
            cmd.Parameters.AddWithValue("@stylistId", this.Id);
            cmd.ExecuteNonQuery();

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            StartDate = startDate;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Client> GetClients()
        {
            List<Client> allStylistClients = new List<Client> {};

            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", this.Id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                int stylistId = rdr.GetInt32(1);
                string clientFirstName = rdr.GetString(2);
                string clientLastName = rdr.GetString(3);
                string clientEmail = rdr.GetString(4);
                string clientNotes = rdr.GetString(5);
                Client newClient = new Client(stylistId, clientFirstName, clientLastName, clientEmail, clientNotes, clientId);
                allStylistClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylistClients;
        }
    }
}
