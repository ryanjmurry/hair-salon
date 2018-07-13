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
    }
}