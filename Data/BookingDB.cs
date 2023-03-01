using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RentalCar.Models;

namespace RentalCar.Daten
{
    internal class BookingDB
    {
        // Liste der Buchungen
        private List<Booking> bookings = new List<Booking>();

        internal int GetHighestID() { return bookings.Count + 1; }

        internal List<Booking> GetBookings() { return bookings; }

        internal Booking GetBooking(int id) { return bookings[id]; }
        internal void AddBookingToList(Booking booking) => bookings.Add(booking);

        internal void CreateBooking(CustomerDB customerDb , CarDB carDb)
        {
            Booking booking = new Booking();
            booking.Id = GetHighestID();

            // Gast abfragen
            Console.WriteLine("Bitte ID des Gastes angeben...");
            int idGuest = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln und checken ob in Range
            var resGuest = customerDb.CheckIfIdInRange(idGuest);

            if (resGuest == true)
            {
                Customer customer = customerDb.GetCustomer(idGuest - 1); //Gast mit passender ID wählen
                booking.Customer = customer;
            }
            else
            {
                Console.WriteLine("Gast konnte nicht bestimmt werden");
                return;
            }

            //Auto abfragen
            Console.WriteLine("Bitte ID des Autos angeben...");
            int idCar = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln und checken ob in Range
            var resCar = carDb.CheckIfIdInRange(idCar);

            if (resCar == true)
            {
                Car car = carDb.GetCar(idCar - 1); //Gast mit passender ID wählen
                if (car.Available == false)
                {
                    Console.WriteLine("Auto leider nicht verfügbar");
                    return;
                }
                else
                {
                    car.Available = false;
                    booking.Car = car;
                }
            }
            else
            {
                Console.WriteLine("Auto konnte nicht bestimmt werden");
                return;
            }

            // Anzahl der Miettage 
            Console.WriteLine("Wie viele Tage soll gemietet werden?");
            int amountDays = Convert.ToInt32(Console.ReadLine()); // Eingabe der Anzahl der Tage die gemietet werden sollen 
            booking.To = DateTime.Now.AddDays(amountDays);

            // Kosten für die Mietung 
            Console.WriteLine("Bitte Preis angeben");
            double price = Convert.ToDouble(Console.ReadLine()); // Eingabe der Anzahl der Tage die gemietet werden sollen 
            booking.Price = price;
            bookings.Add(booking);

            AddToCloud(booking);

            return;
        }

        private void AddToCloud(Booking booking)
        {
            // Verbindungszeichenfolge zur MongoDB Atlas-Datenbank -> Erstellen Sie eine Instanz des MongoClient -> Datenbank
            var client = new MongoClient("mongodb+srv://RentalCar:DSoh8IQ54Elj2myr@cluster0.xmlqw5t.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("RentalCar");

            // Wählen Sie die Sammlung aus
            var collection = database.GetCollection<BsonDocument>("bookings");

            // Fügen Sie die Liste von Objekten in die MongoDB-Sammlung ein
            collection.InsertOne(booking.ToBsonDocument());
        }

        internal void ShowAllBookings()
        {
            foreach (var item in bookings)
            {
                Console.WriteLine(item);
            }
        }

        private bool CheckIfIdInRange(int id)
        {
            if (id >= GetAmountItems()) // checken ob keine zu hohe ID eingegeben wurde
            {
                Console.WriteLine("ID nicht vorhanden");
                return false;
            }
            else { return true; }
        }

        internal int GetAmountItems()
        {
            return bookings.Count;
        }

        internal void FinishBooking()
        {
            Console.WriteLine("Welche Buchung soll abgeschlossen werden? Bitte ID angeben!");
            int id = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
            bool res = CheckIfIdInRange(id);
            if (res == true)
            {
                var currentBooking = GetBooking(id - 1);
                currentBooking.IsFinished = true;

                Customer currentCustomer = currentBooking.Customer;
                currentCustomer.AmountBookings++;

                Car currentCar = currentBooking.Car;
                currentCar.Available = true;

                Console.WriteLine("Wie viele KM wurden gefahren?");
                int km = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
                currentBooking.AmountKM = km;
                currentCar.DistanceKm = currentCar.DistanceKm + km;
            }
        }
        /*public void saveData()
       {
           string json = JsonConvert.SerializeObject(bookings);
           File.WriteAllText(@".\Bookingdata.json", json);
       }*/
    }
}
