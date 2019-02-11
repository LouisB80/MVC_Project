using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext() : base("AgendaContext") { }

        public DbSet<Appointement> Appointements { get; set; }
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}