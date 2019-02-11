using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Broker
    {
        public int BrokerID { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(100), Required]
        public string Mail { get; set; }
        [MaxLength(10), Required]
        public string phoneNumber { get; set; }
        public virtual ICollection<Appointement> Appointements { get; set; }
    }
}