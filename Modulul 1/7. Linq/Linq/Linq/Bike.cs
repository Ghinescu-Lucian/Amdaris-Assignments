using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Linq
{
    public class Bike
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public double Weight { get; set; }

        public bool HasSuspension { get; set; }

        public string ProducerId { get; set; }

        public override string ToString()
        {
            return $"{Model} {Year} on year. {Year} {(HasSuspension? " has suspension" : "")}";
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Bike b = (Bike)obj;
                return (Model == b.Model) && (Year == b.Year);
            }
        }

        public override int GetHashCode()
        {
            return (Year+" ; "+Model).GetHashCode();
        }
    }

    public class FullSuspensionBike : Bike
    {
        public string BackSuspension { get; set; }
    }

    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Bike> Models { get; set; }
    }
}