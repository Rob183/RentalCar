using MongoDB.Driver;
using RentalCar.Daten;
using RentalCar.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string exit = "exit";
        // Neue Objekte für Auto,Kunden und BuchungsDatenbank
        CarDB carDb = new CarDB();
        CustomerDB customerDb = new CustomerDB();
        BookingDB bookingDB = new BookingDB();

        //ReloadData();
        ReloadCloudData();
        //tryConnection();

        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("Bitte wählen..");
            Console.WriteLine("1. Auto anlegen");
            Console.WriteLine("2. Autos anzeigen");
            Console.WriteLine("3. Auto bearbeiten");
            Console.WriteLine("4. Auto löschen");
            Console.WriteLine("5. Kunde anlegen");
            Console.WriteLine("6. Kunden anzeigen");
            Console.WriteLine("7. Kunde bearbeiten");
            Console.WriteLine("8. Kunde löschen");
            Console.WriteLine("9. Buchung anlegen");
            Console.WriteLine("10. Buchung anzeigen");
            Console.WriteLine("11. Buchung abschließen");
            Console.WriteLine("12. Vermietete Autos anzeigen");
            Console.WriteLine($"({exit}) Beenden");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    carDb.AddCar();
                    Console.WriteLine();
                    break;

                case "2":
                    carDb.ShowAllCars();
                    Console.WriteLine();
                    break;

                case "3":
                    carDb.ChangeCar();
                    Console.WriteLine();
                    break;

                case "4":
                    carDb.DeleteCar();
                    Console.WriteLine();
                    break;

                case "5":
                    customerDb.AddCustomer();
                    Console.WriteLine();
                    break;

                case "6":
                    customerDb.ShowAllCustomers();
                    Console.WriteLine();
                    break;

                case "7":
                    customerDb.ChangeCustomer();
                    Console.WriteLine();
                    break;

                case "8":
                    customerDb.DeleteCustomer();
                    Console.WriteLine();
                    break;

                case "9":
                    bookingDB.CreateBooking(customerDb, carDb);
                    Console.WriteLine();
                    break;

                case "10":
                    bookingDB.ShowAllBookings();
                    Console.WriteLine();
                    break;

                case "11":
                    bookingDB.FinishBooking();
                    Console.WriteLine();
                    break;

                case "12":
                    carDb.ShowUnavailableCars();
                    Console.WriteLine();
                    break;

                case "exit":
                    //carDb.saveData();
                    //customerDb.saveData();
                    //bookingDB.saveData();
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("falsche Eingabe: " + input);
                    break;
            }
        };

       /* void ReloadData()
        {
            try
            {
                // Lese JSON-Daten aus Dateien
                string jsonCar = File.ReadAllText(@".\Cardata.json");
                string jsonCustomer = File.ReadAllText(@".\Customersdata.json");
                string jsonBookings = File.ReadAllText(@".\Bookingdata.json");

                // Deserialisiere JSON-Daten in Objekte
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(jsonCar);
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonCustomer);
                List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(jsonBookings);

                // Füge Objekte in Datenbanken ein
                foreach (Car car in cars)
                {
                    carDb.AddCarsToList(car);
                }

                foreach (Customer customer in customers)
                {
                    customerDb.AddCustomerToList(customer);
                }

                foreach (Booking booking in bookings)
                {
                    bookingDB.AddBookingToList(booking);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Daten: " + ex.Message);
            }
        }*/

        void ReloadCloudData()
        {
            try
            {
                // Erstellt eine Instanz des MongoClient
                var client = new MongoClient("mongodb+srv://RentalCar:DSoh8IQ54Elj2myr@cluster0.xmlqw5t.mongodb.net/?retryWrites=true&w=majority");

                // Wahl der Datenbank
                var database = client.GetDatabase("RentalCar");

                // Sammlungen
                var collectionCar = database.GetCollection<Car>("cars");
                var collectionCust = database.GetCollection<Customer>("customers");
                var collectionBooking = database.GetCollection<Booking>("bookings");

                // Liste mit allen Inhalten erstellen
                var documentsCar = collectionCar.Find(_ => true).ToList();
                var documentsCustomer = collectionCust.Find(_ => true).ToList();
                var documentsBooking = collectionBooking.Find(_ => true).ToList();

                // Autos erstellen
                foreach (var item in documentsCar)
                {
                    Car car = item;
                    carDb.AddCarsToList(car);
                }

                // Kunden erstellen
                foreach (var item in documentsCustomer)
                {
                    Customer cust = item;
                    customerDb.AddCustomerToList(cust);
                }

                // Buchungen erstellen
                foreach (var item in documentsBooking)
                {
                    Booking booking = item;
                    bookingDB.AddBookingToList(booking);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Daten: " + ex.Message);
            }
        }
    }

    /* private static void tryConnection()
    {
        string connectionString = "mongodb+srv://RentalCar:DSoh8IQ54Elj2myr@cluster0.xmlqw5t.mongodb.net/?retryWrites=true&w=majority";

        // Erstellen Sie eine Instanz des MongoClient
        var client = new MongoClient(connectionString);


        // Überprüfen Sie, ob eine Verbindung zur Datenbank hergestellt werden kann
        try
        {
            var dbList = client.ListDatabases().ToList();
            // Rufen Sie eine Liste der vorhandenen Datenbanken ab
            Console.WriteLine("Die Verbindung zur Datenbank wurde erfolgreich hergestellt. Folgende Datenbanken sind verfügbar:");
            foreach (var databaseName in dbList)
            {
                Console.WriteLine(databaseName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler beim Herstellen der Verbindung zur Datenbank:");
            Console.WriteLine(ex.Message);
        }
    } */
}