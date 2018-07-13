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
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date, 1);
            Assert.AreEqual("Bob", testStylist.Name);
            Assert.AreEqual("bob@aol.com", testStylist.Email);
            Assert.AreEqual("123 Abc Road", testStylist.Street);
            Assert.AreEqual("Bend", testStylist.City);
            Assert.AreEqual("OR", testStylist.State);
            Assert.AreEqual("12345", testStylist.Zip);
            Assert.AreEqual(date, testStylist.StartDate);
            Assert.AreEqual(1, testStylist.Id);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfPropertiesMatch_Stylist()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist stylist1 = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date, 1);
            Stylist stylist2 = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date, 1);
            Assert.AreEqual(stylist1, stylist2);
        }

        [TestMethod]
        public void GetAll_DatabaseStartsEmpty_0()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist.Save();
            List<Stylist> expectedList = new List<Stylist> { testStylist };
            List<Stylist> actualList = Stylist.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist.Save();
            Stylist savedStylist = Stylist.GetAll()[0];
            int testId = testStylist.Id;
            int result = savedStylist.Id;
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllStylistsInDatabase_StylistList()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist.Save();
            Stylist.DeleteAll();
            List<Stylist> expectedList = new List<Stylist> { };
            List<Stylist> actualList = Stylist.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Find_FindStylistInDatabase_Stylist()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist.Save();
            Stylist foundStylist = Stylist.FindStylist(testStylist.Id);
            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void Delete_DeletesStylistFromDatabase_StylistList()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist1 = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist1.Save();
            Stylist testStylist2 = new Stylist("Bill", "bill@aol.com", "456 Xyz Road", "Salem", "OR", "67890", date);
            testStylist2.Save();
            Stylist.Delete(testStylist1.Id);
            List<Stylist> expectedList = new List<Stylist> { testStylist2 };
            List<Stylist> actualList = Stylist.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Update_UpdateStylistFromDatabase_String()
        {
            DateTime date = new DateTime(2018, 07, 13);
            Stylist testStylist = new Stylist("Bob", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            testStylist.Save();
            testStylist.Update("Bill", "bob@aol.com", "123 Abc Road", "Bend", "OR", "12345", date);
            string actualName = Stylist.FindStylist(testStylist.Id).Name;
            Assert.AreEqual("Bill", actualName);
        }
    }
}
