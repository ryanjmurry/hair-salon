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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime StartDate { get; set; }
        public int Id { get; set; }

        public Stylist(string firstName, string lastName, string phoneNumber, string email, string street, string city, string state, string zip, DateTime startDate, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            StartDate = startDate.Date;
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
                bool phoneNumberEquality = (this.PhoneNumber == newStylist.PhoneNumber);
                bool emailEquality = (this.Email == newStylist.Email);
                bool streetEquality = (this.Street == newStylist.Street);
                bool cityEquality = (this.City == newStylist.City);
                bool stateEquality = (this.State == newStylist.State);
                bool zipEquality = (this.Zip == newStylist.Zip);
                bool startDateEquality = (this.StartDate == newStylist.StartDate);
                bool idEquality = (this.Id == newStylist.Id);
                
                return (firstNameEquality && lastNameEquality && phoneNumberEquality &&emailEquality && streetEquality && cityEquality && stateEquality && zipEquality && startDateEquality && idEquality);
            }
        }

        public static List<Stylist> GetAll()
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (first_name, last_name, phone_number, email, street, city, state, zip, start_date) VALUES (@stylistFirstName, @stylistLastName, @stylistPhoneNumber, @stylistEmail, @stylistStreet, @stylistCity, @stylistState, @stylistZip, @stylistStartDate);";

            cmd.Parameters.AddWithValue("@stylistFirstName", this.FirstName);
            cmd.Parameters.AddWithValue("@stylistLastName", this.LastName);
            cmd.Parameters.AddWithValue("@stylistPhoneNumber", this.PhoneNumber);
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
                string stylistPhoneNumber = "";
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
                stylistPhoneNumber = rdr.GetString(3);
                stylistEmail = rdr.GetString(4);
                stylistStreet = rdr.GetString(5);
                stylistCity = rdr.GetString(6);
                stylistState = rdr.GetString(7);
                stylistZip = rdr.GetString(8);
                stylistStartDate = rdr.GetDateTime(9);
            }

            Stylist foundStylist = new Stylist(stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);

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

        public void Update(string firstName, string lastName, string phoneNumber, string email, string street, string city, string state, string zip, int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET first_name = @stylistFirstName, last_name = @stylistLastName, phone_number = @stylistPhoneNumber, email = @stylistEmail, street = @stylistStreet, city = @stylistCity, state = @stylistState, zip = @stylistZip WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistFirstName", firstName);
            cmd.Parameters.AddWithValue("@stylistLastName", lastName);
            cmd.Parameters.AddWithValue("@stylistPhoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@stylistEmail", email);
            cmd.Parameters.AddWithValue("@stylistStreet", street);
            cmd.Parameters.AddWithValue("@stylistCity", city);
            cmd.Parameters.AddWithValue("@stylistState", state);
            cmd.Parameters.AddWithValue("@stylistZip", zip);
            cmd.Parameters.AddWithValue("@stylistId", id);
            cmd.ExecuteNonQuery();

            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Street = street;
            City = city;
            State = state;
            Zip = zip;

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
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId ORDER BY last_name;";
            cmd.Parameters.AddWithValue("@stylistId", this.Id);
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
                allStylistClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylistClients;
        }

        public string ConvertDateToString(DateTime date)
        {
            string format = "MMM d, yyyy";
            return date.ToString(format);
        }

        // public static string EmailAll(List<Stylist> allStylists)
        // {
        //     List<string> allEmails = new List<string> {};
        //     foreach(Stylist stylist in allStylists)
        //     {
        //         allEmails.Add(stylist.Email);
        //     }
        //     string emails = String.Join(",", allEmails);
        //     return emails;
        // }
    }
}
