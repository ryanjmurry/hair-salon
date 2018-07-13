using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylist")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll(); 
            return View(allStylists);
        }
    }
}