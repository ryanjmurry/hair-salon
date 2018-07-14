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
    }
}