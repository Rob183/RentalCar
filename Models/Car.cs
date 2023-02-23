using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public string DistanceKm { get; set; }


        public override string ToString()
        {
            return $"Id: {Id} , Hersteller: {Manufacturer}";
        }
    }
}
