using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
[   TestClass]
    public class StylistsControllerTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistsControllerTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ryan_murry_test;";
        }

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult Index = controller.Index();

            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_ItemList()
        {
            StylistsController controller = new StylistsController();
            ActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;
            var result = indexView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void Form_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult Form = controller.Form();

            Assert.IsInstanceOfType(Form, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult Details = controller.Details(0);

            Assert.IsInstanceOfType(Details, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_ItemList()
        {
            StylistsController controller = new StylistsController();
            ActionResult actionResult = controller.Details(0);
            ViewResult detailsView = controller.Details(0) as ViewResult;
            var result = detailsView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }

        [TestMethod]
        public void UpdateForm_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult UpdateForm = controller.UpdateForm(0);

            Assert.IsInstanceOfType(UpdateForm, typeof(ViewResult));
        }

        [TestMethod]
        public void UpdateForm_HasCorrectModelType_ItemList()
        {
            StylistsController controller = new StylistsController();
            ActionResult actionResult = controller.UpdateForm(0);
            ViewResult updateFormView = controller.UpdateForm(0) as ViewResult;
            var result = updateFormView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }

        [TestMethod]
        public void DeleteAllConfirmation_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult DeleteAllConfirmation = controller.DeleteAllConfirmation();

            Assert.IsInstanceOfType(DeleteAllConfirmation, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteStylistConfirmation_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();

            ActionResult DeleteStylistConfirmation = controller.DeleteStylistConfirmation(0);

            Assert.IsInstanceOfType(DeleteStylistConfirmation, typeof(ViewResult));
        }

        [TestMethod]
        public void DeleteStylistConfirmation_HasCorrectModelType_ItemList()
        {
            StylistsController controller = new StylistsController();
            ActionResult actionResult = controller.DeleteStylistConfirmation(0);
            ViewResult deleteStylistConfirmationView = controller.DeleteStylistConfirmation(0) as ViewResult;
            var result = deleteStylistConfirmationView.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }

    }
}
