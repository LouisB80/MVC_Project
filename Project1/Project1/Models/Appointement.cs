using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class Appointement
    {
        public int AppointementID { get; set; }
        public DateTime DateTime { get; set; }

        public int BrokerID { get; set; }
        public int CustomerID { get; set; }

        public virtual Broker Broker { get; set; }
        public virtual Customer Customer { get; set; }
    }
}