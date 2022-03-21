using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Order
    {
        private static int initialid = 0;
        private DateTime DateTime { get; set; }
        public float TotalCost { get; set; }
        private User User { get; set; }
        private string NrTelephone { get; set; }
        private string Address { get; set; }

        

        public Order( float totalCost, User user,string address, string nrTelefon)
        {
            DateTime d = DateTime.Now;
            DateTime = d;
            TotalCost = totalCost;
            User = user;
            NrTelephone = nrTelefon;
            Address = address;
        }
    }
}
