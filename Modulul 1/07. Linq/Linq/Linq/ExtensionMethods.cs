using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public static class ExtensionMethods
    {
        public static double GetBikeCoeficient(this Bike b)
        {
            return b.Year / b.Weight;

        }

        public static string GetUsernameAndEmail(this User u)
        {
            string us = u.Username + " " + u.Email;
            return us;
        }

        public static double GetDiscountedPrice(this Order o, double percentage = .2f)
        {
            double promo = o.TotalCost - percentage * o.TotalCost;
            return promo;
        }

    }
}
