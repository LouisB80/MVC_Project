using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            ViewData["date"] = DateTime.Now;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointement()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBroker([Bind(Include = "LastName, FirstName, Mail, PhoneNumber")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Brokers.Add(broker);
                db.SaveChanges();
                return RedirectToAction("ListBrokers");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer([Bind(Include = "LastName, FirstName, Mail, PhoneNumber, Budget, Subject")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("ListCustomers");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "LastName, FirstName, Mail, PhoneNumber, Budget, Subject")] Customer customer)
        {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBroker([Bind(Include = "LastName, FirstName, Mail, PhoneNumber")]Broker brokers)
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
            List<Customer> customers = db.Customers.ToList();
            return View(customers);
        }


        public ActionResult ProfilBroker(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Brokers.Find(id);
            if(broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }


        public ActionResult ProfilCustomer(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }   
}