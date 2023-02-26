using System;
using System.IO;
using System.Text;
using System.Runtime.ConstrainedExecution;
using RentalCar.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

using System.Text.Json;
using RentalCar.Daten;

string exit = "exit";

CarDB carDb = new CarDB();
CustomerDB customerDb = new CustomerDB();
BookingDB bookingDB = new BookingDB();

ReloadData();

string input;
do
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

    input = Console.ReadLine();
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
            carDb.saveData();
            customerDb.saveData();
            bookingDB.saveData();
            break;

        default:
            Console.WriteLine("falsche Eingabe");
            break;
    }
} while (input != exit);

void ReloadData()
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
}