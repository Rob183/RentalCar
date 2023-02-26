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
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }

        public bool Available { get; set; }
        public int? DistanceKm { get; set; }

        public Car(int id)
        {
            Id = id;
            Available = true;
        }
        public override string ToString() => $"Id: {Id}; Hersteller: {Manufacturer}; Model: {Model}; KM: {DistanceKm} ; Verfügbar: {Available}";
    }
}
