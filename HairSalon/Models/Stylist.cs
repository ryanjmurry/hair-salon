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
        public int Zip { get; set; }
        public DateTime StartDate { get; set; }
        public int Id { get; set; }

        public Stylist(string name, string email, string street, string city, string state, int zip, DateTime startDate, int id = 0)
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
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string email = rdr.GetString(2);
                string street = rdr.GetString(3);
                string city = rdr.GetString(4);
                string state = rdr.GetString(5);
                int zip = rdr.GetInt32(6);
                DateTime startDate = rdr.GetDateTime(7);
                Stylist newStylist = new Stylist(name, email, street, city, state, zip, startDate, id);
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
            cmd.CommandText = @"INSERT INTO stylists (name, email, street, city, state, zip, start_date) VALUES (@StylistName, @StylistEmail, @StylistStreet, @StylistCity, @StylistState, @StylistZip, @StylistStartDate);";

            cmd.Parameters.AddWithValue("@StylistName", this.Name);
            cmd.Parameters.AddWithValue("@StylistEmail", this.Email);
            cmd.Parameters.AddWithValue("@StylistStreet", this.Street);
            cmd.Parameters.AddWithValue("@StylistCity", this.City);
            cmd.Parameters.AddWithValue("@StylistState", this.State);
            cmd.Parameters.AddWithValue("@StylistZip", this.Zip);
            cmd.Parameters.AddWithValue("@StylistStartDate", this.StartDate);
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
            if(conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
