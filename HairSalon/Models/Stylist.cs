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

        public static void DeleteAll()
        {

        }
    }
}
