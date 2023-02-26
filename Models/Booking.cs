using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public Car? Car { get; set; }
        public DateTime From { get; set; }

        public DateTime To { get; set; }
        public double Price  { get; set; }

        public bool IsFinished { get; set; }
        public int AmountKM { get; set; }

        public Booking()
        {
            From = DateTime.Now;
            IsFinished = false;
        }
        public override string ToString() => $"Id: {Id};" +
            System.Environment.NewLine + $" Kunde: {Customer};" +
            System.Environment.NewLine + $" Auto: {Car}; " +
            System.Environment.NewLine + $" Kosten: {Price.ToString()} Euro;" +
            System.Environment.NewLine + $" Gebucht von: {From} bis: {To.ToString()}; " +
            System.Environment.NewLine + $" KM gefahren: {AmountKM.ToString()}; " +
            System.Environment.NewLine + $" ABGESCHLOSSEN?: {IsFinished.ToString()}";

    }
}
