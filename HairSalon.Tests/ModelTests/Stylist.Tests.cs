using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_murry_test;";
        }

        [TestMethod]
        public void Stylist_InstantiatesStylistAndGetsProperties_Properties()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist newStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", 12345, date, 1);
            Assert.AreEqual("Bob", newStylist.Name);
            Assert.AreEqual("bob@aol.com", newStylist.Email);
            Assert.AreEqual("123 Abc Road", newStylist.Street);
            Assert.AreEqual("Bend", newStylist.City);
            Assert.AreEqual("OR", newStylist.State);
            Assert.AreEqual(12345, newStylist.Zip);
            Assert.AreEqual(date, newStylist.StartDate);
            Assert.AreEqual(1, newStylist.Id);
        }

    }
}
