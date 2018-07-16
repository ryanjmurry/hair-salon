using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
 [TestClass]
    public class ClientsControllerTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public ClientsControllerTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_murry_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult Index = controller.Index();

            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_ClientList()
        {
            ClientsController controller = new ClientsController();
            ActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Client>));
        }

        [TestMethod]
        public void Form_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult Form = controller.Form();

            Assert.IsInstanceOfType(Form, typeof(ViewResult));
        }

        [TestMethod]
        public void Form_HasCorrectModelType_StylistList()
        {
            ClientsController controller = new ClientsController();
            ActionResult actionResult = controller.Form();
            ViewResult formView = controller.Form() as ViewResult;
            var result = formView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult Details = controller.Details(0);

            Assert.IsInstanceOfType(Details, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_Client()
        {
            ClientsController controller = new ClientsController();
            ActionResult actionResult = controller.Details(0);
            ViewResult detailsView = controller.Details(0) as ViewResult;
            var result = detailsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Client));
        }

        [TestMethod]
        public void UpdateForm_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult UpdateForm = controller.UpdateForm(0);

            Assert.IsInstanceOfType(UpdateForm, typeof(ViewResult));
        }

        [TestMethod]
        public void UpdateForm_HasCorrectModelType_Client()
        {
            ClientsController controller = new ClientsController();
            ActionResult actionResult = controller.UpdateForm(0);
            ViewResult updateFormView = controller.UpdateForm(0) as ViewResult;
            var result = updateFormView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Client));
        }

        [TestMethod]
        public void DeleteAllConfirmation_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult DeleteAllConfirmation = controller.DeleteAllConfirmation();

            Assert.IsInstanceOfType(DeleteAllConfirmation, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteClientConfirmation_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();

            ActionResult DeleteStylistConfirmation = controller.DeleteClientConfirmation(0);

            Assert.IsInstanceOfType(DeleteStylistConfirmation, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteStylistConfirmation_HasCorrectModelType_Client()
        {
            ClientsController controller = new ClientsController();
            ActionResult actionResult = controller.DeleteClientConfirmation(0);
            ViewResult deleteClientConfirmationView = controller.DeleteClientConfirmation(0) as ViewResult;
            var result = deleteClientConfirmationView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Client));
        }

    }
}
