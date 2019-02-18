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
        [Display(Name = "Nom :")]
        public string LastName { get; set; }
        [MaxLength(50), Required]
        [Display(Name ="Prenom :")]
        public string FirstName { get; set; }
        [MaxLength(100), Required]
        [Display(Name = "Adresse Mail :")]
        [EmailAddress]
        public string Mail { get; set; }
        [MaxLength(10), Required]
        [Display(Name = "Tél :")]
        [RegularExpression(@"^0[0-9]{9}$")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Appointement> Appointements { get; set; }
    }
}