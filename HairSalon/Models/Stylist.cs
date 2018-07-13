using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime StartDate { get; set; }
        public int Id { get; set; }

        public Stylist(string name, string email, string street, string city, string state, string zip, DateTime startDate, int id = 0)
        {
            Name = name;
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
                
                bool nameEquality = (this.Name == newStylist.Name);
                bool emailEquality = (this.Email == newStylist.Email);
                bool streetEquality = (this.Street == newStylist.Street);
                bool cityEquality = (this.City == newStylist.City);
                bool stateEquality = (this.State == newStylist.State);
                bool zipEquality = (this.Zip == newStylist.Zip);
                bool dateEquality = (this.StartDate == newStylist.StartDate);
                bool idEquality = (this.Id == newStylist.Id);
                
                return (nameEquality && emailEquality && streetEquality && cityEquality && stateEquality && zipEquality && dateEquality && idEquality);
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
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistEmail = rdr.GetString(2);
                string stylistStreet = rdr.GetString(3);
                string stylistCity = rdr.GetString(4);
                string stylistState = rdr.GetString(5);
                string stylistZip = rdr.GetString(6);
                DateTime stylistStartDate = rdr.GetDateTime(7);
                Stylist newStylist = new Stylist(stylistName, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);
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
            cmd.CommandText = @"INSERT INTO stylists (name, email, street, city, state, zip, start_date) VALUES (@stylistName, @stylistEmail, @stylistStreet, @stylistCity, @stylistState, @stylistZip, @stylistStartDate);";

            cmd.Parameters.AddWithValue("@stylistName", this.Name);
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

        public static Stylist FindStylist(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        
                int stylistId = 0;
                string stylistName = "";
                string stylistEmail = "";
                string stylistStreet = "";
                string stylistCity = "";
                string stylistState = "";
                string stylistZip = "";
                DateTime stylistStartDate = new DateTime(); 

            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                stylistEmail = rdr.GetString(2);
                stylistStreet = rdr.GetString(3);
                stylistCity = rdr.GetString(4);
                stylistState = rdr.GetString(5);
                stylistZip = rdr.GetString(6);
                stylistStartDate = rdr.GetDateTime(7);
            }

            Stylist foundStylist = new Stylist(stylistName, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, stylistStartDate, stylistId);

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

        public void Update(string name, string email, string street, string city, string state, string zip, DateTime startDate)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = @stylistName, email = @stylistEmail, street = @stylistStreet, city = @stylistCity, state = @stylistState, zip = @stylistZip, start_date = @stylistStartDate WHERE id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistName", name);
            cmd.Parameters.AddWithValue("@stylistEmail", email);
            cmd.Parameters.AddWithValue("@stylistStreet", street);
            cmd.Parameters.AddWithValue("@stylistCity", city);
            cmd.Parameters.AddWithValue("@stylistState", state);
            cmd.Parameters.AddWithValue("@stylistZip", zip);
            cmd.Parameters.AddWithValue("@stylistStartDate", startDate);
            cmd.Parameters.AddWithValue("@stylistId", this.Id);
            cmd.ExecuteNonQuery();

            Name = name;
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
    }
}
