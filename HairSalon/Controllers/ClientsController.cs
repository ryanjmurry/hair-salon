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
            List<Stylist> allStylists = Stylist.GetAll();
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

        [HttpGet("/clients/delete")]
        public ActionResult DeleteAllConfirmation()
        {
            return View();
        }
        [HttpPost("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();
            return RedirectToAction("Index");

        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult DeleteClientConfirmation(int id)
        {
            Client currentClient = Client.Find(id);
            return View(currentClient);
        }

        [HttpPost("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/update")]
        public ActionResult UpdateForm(int id)
        {
            Client currentClient = Client.Find(id);
            return View(currentClient);
        }

        [HttpPost("/clients/{id}/update")]
        public ActionResult UpdateClient(int stylistId, string clientFirstName, string clientLastName, string clientPhoneNumber, string clientEmail, string clientNotes, int id)
        {
            Client currentClient = Client.Find(id);
            currentClient.Update(stylistId, clientFirstName, clientLastName, clientPhoneNumber, clientEmail, clientNotes);
            return RedirectToAction("Details", new { id = currentClient.Id});
        }
    }
}