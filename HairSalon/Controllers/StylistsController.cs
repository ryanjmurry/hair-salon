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

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist currentStylist = Stylist.Find(id);
            return View(currentStylist);
        }

        [HttpPost("/stylists/new")]
        public ActionResult CreateStylist(string stylistFirstName, string stylistLastName, string stylistPhoneNumber, string stylistEmail, string stylistStreet, string stylistCity, string stylistState, string stylistZip)
        {
            DateTime startDate = DateTime.Now;
            Stylist newStylist = new Stylist(stylistFirstName, stylistLastName, stylistPhoneNumber, stylistEmail, stylistStreet, stylistCity, stylistState, stylistZip, startDate);
            newStylist.Save();
            return RedirectToAction("Details", new { id = newStylist.Id});
        }
    }
}