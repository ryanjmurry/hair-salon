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

        [TestMethod]
        public void Equals_ReturnsTrueIfPropertiesMatch_Stylist()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist stylist1 = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", 12345, date, 1);
            Stylist stylist2 = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", 12345, date, 1);
            Assert.AreEqual(stylist1, stylist2);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist newStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", 12345, date);
            newStylist.Save();
            List<Stylist> expectedList = new List<Stylist> { newStylist };
            List<Stylist> actualList = Stylist.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllStylistsInDatabase_Stylist()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist newStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", 12345, date);
            newStylist.Save();
            Stylist.DeleteAll();
            List<Stylist> expectedList = new List<Stylist> { };
            List<Stylist> actualList = Stylist.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

    }
}
