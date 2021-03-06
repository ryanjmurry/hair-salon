using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            allStylists = Stylist.GetAll(); 
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost("/stylists/new")]
        public ActionResult CreateStylist(string stylistFirstName, string stylistLastName, string stylistPhoneNumber, string stylistEmail, string stylistStreet, string stylistCity, string stylistState, string stylistZip)
        {
            DateTime startDate = DateTime.Now;
            Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, startDate);
            newStylist.Save();
            return RedirectToAction("Details", new { id = newStylist.Id});
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
        }

        [HttpGet("/stylists/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
        }

        [HttpPost("/stylists/{id}/update")]
        public ActionResult UpdateStylist(string stylistFirstName, string stylistLastName, string stylistPhoneNumber, string stylistEmail, string stylistStreet, string stylistCity, string stylistState, string stylistZip, int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            currentStylist.Update(stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, id);
            return RedirectToAction("Details", new { id = currentStylist.Id});
        }

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAllConfirmation()
        {
            return View();
        }

        [HttpPost("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();
            return RedirectToAction("Index");

        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult DeleteStylistConfirmation(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
        }

        [HttpPost("/stylists/{id}/delete")]
        public ActionResult DeleteStylist(int id)
        {
            Stylist.Delete(id);
            return RedirectToAction("Index");
        }
    }
}