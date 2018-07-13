using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_murry_test;";
        }

        [TestMethod]
        public void Client_InstantiatesClientAndGetsProperties_Properties()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald", 1);
            Assert.AreEqual(1, testClient.StylistId);
            Assert.AreEqual("Jeff", testClient.Name);
            Assert.AreEqual("jeff@aol.com", testClient.Email);
            Assert.AreEqual("bald", testClient.Notes);
            Assert.AreEqual(1, testClient.Id);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfPropertiesMatch_Client()
        {
            Client testClient1 = new Client(1, "Jeff", "jeff@aol.com", "bald", 1);
            Client testClient2 = new Client(1, "Jeff", "jeff@aol.com", "bald", 1);
            Assert.AreEqual(testClient1, testClient2);
        }

        [TestMethod]
        public void GetAll_DatabaseStartsEmpty_0()
        {
            int result = Client.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesClientToDatabase_ClientList()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient.Save();
            List<Client> expectedList = new List<Client> { testClient };
            List<Client> actualList = Client.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient.Save();
            Client resultClient = Client.GetAll()[0];
            int result = resultClient.Id;
            int expected = testClient.Id;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteAll_DeletesAllClientsInDatabase_ClientList()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient.Save();
            Client.DeleteAll();
            List<Client> expectedList = new List<Client> {};
            List<Client> actualList = Client.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Find_FindClientInDatabase_Client()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient.Save();
            Client foundClient = Client.Find(testClient.Id);
            Assert.AreEqual(testClient, foundClient);
        }

        [TestMethod]
        public void Delete_DeletesClientFromDatabase_ClientList()
        {
            Client testClient1 = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient1.Save();
            Client testClient2 = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient2.Save();
            testClient1.Delete();
            List<Client> expectedList = new List<Client> { testClient2 };
            List<Client> actualList = Client.GetAll();
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod]
        public void Update_UpdateClientFromDatabase_String()
        {
            Client testClient = new Client(1, "Jeff", "jeff@aol.com", "bald");
            testClient.Save();
            testClient.Update(1, "Geoff", "jeff@aol.com", "bald");
            string actual = Client.Find(testClient.Id).Name;
            Assert.AreEqual("Geoff", actual);
        }
    }
}