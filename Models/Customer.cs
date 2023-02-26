using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int AmountBookings { get; set; }

        public Customer(int id)
        {
            Id = id;
            AmountBookings = 0;
        }
        public override string ToString() => $"Id: {Id}; Vorname: {FirstName}; Nachname: {LastName}; Adresse: {Address}";
    }
}
