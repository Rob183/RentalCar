using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    internal class Booking
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
