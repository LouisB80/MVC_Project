using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private AgendaContext db = new AgendaContext();
        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult AddBroker()
        {
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        public ActionResult AddAppointement()
        {
            return View();
        }
        public ActionResult ListBrokers()
        {
            List<Broker> brokers = db.Brokers.ToList();
            return View(brokers);
        }
        public ActionResult ListCustomers()
        {
            return View();
        }
        public ActionResult ProfilBrokers()
        {
            return View();
        }
    }
    
}