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
    }
}
