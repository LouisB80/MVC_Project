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


        public ActionResult AddBroker()
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


        public ActionResult AddCustomer()
        {
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

        public ActionResult EditCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "LastName, FirstName, Mail, PhoneNumber, Budget, Subject")] Customer customer)
        {
            var CustomerToUpdate = db.Customers.Find(customer.CustomerID);
            if (ModelState.IsValid)     
            {
                db.Entry(customer).State = EntityState.Modified;
                try
                {                    
                    db.SaveChanges();
                    return RedirectToAction("ListCustomers");
                }
                catch (DataException)
                {
                    //Si echec:
                    ModelState.AddModelError("", "Une erreur s'est produite, si le problème persiste appelez un technicien");
                }
            }
            return View(CustomerToUpdate);
        }


        public ActionResult EditBroker()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBroker([Bind(Include = "LastName, FirstName, Mail, PhoneNumber")]Broker brokers)
        {
            if (ModelState.IsValid)
            {

                db.Entry(brokers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListCustomer");
            }
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