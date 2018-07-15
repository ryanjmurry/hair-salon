using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = new List<Client> {};
            allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/clients/new")]
        public ActionResult Form()
        {
            List<Stylist> allStylists = Client.GetAllStylists();
            return View(allStylists);
        }

        [HttpPost("/clients/new")]
        public ActionResult CreateClient(int stylistId, string clientFirstName, string clientLastName, string clientPhoneNumber, string clientEmail, string clientNotes)
        {
            Client newClient = new Client(stylistId, clientFirstName, clientLastName, clientPhoneNumber, clientEmail, clientNotes);
            newClient.Save();
            return RedirectToAction("Details", new { id = newClient.Id});
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client currentClient = Client.Find(id);
            return View(currentClient);
        }
    }
}