// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.ConstrainedExecution;

namespace RentalCar;

class Program
{
    private static int carId = 1;
    private static int customerId = 1;
    private static int bookingId= 1;
    private static string exit = "exit";
    private static List<Car> cars = new List<Car>();
    private static List<Customer> customers = new List<Customer>();
    private static List<Booking> bookings = new List<Booking>();

    static void Main(string[] args)
    {
        string input;

        do
        {
            Console.WriteLine("Bitte wählen..");
            Console.WriteLine("1. Auto anlegen");
            Console.WriteLine("2. Autos anzeigen"); 
            Console.WriteLine("3. Kunde anlegen");
            Console.WriteLine("4. Kunden anzeigen");
            Console.WriteLine("5. Buchung anlegen");
            Console.WriteLine("6. Buchung anzeigen");
            Console.WriteLine($"({exit}) Beenden");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Car car = CreateCar();
                    cars.Add(car);
                    break;

                case "2":
                    foreach (var item in cars)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "3":
                    Customer customer = CreateCustomer();
                    customers.Add(customer);
                    break;

                case "4":
                    foreach (var item in customers)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "5":
                    Booking booking = CreateBooking();
                    bookings.Add(booking);
                    break;

                case "6":
                    foreach (var item in customers)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "exit":
                    break;

                default:
                    Console.WriteLine("falsche Eingabe");
                    break;
            }
        } while (input != exit);
    }

    private static Booking CreateBooking()
    {
        Booking booking = new Booking();
        booking.Id = bookingId;
        bookingId++;

        booking.

        return booking;
    }

    private static Customer CreateCustomer()
    {
        Customer customer = new Customer();
        customer.Id = customerId;
        customerId++;

        Console.WriteLine("Vorname angeben...");
        customer.FirstName = Console.ReadLine();
        Console.WriteLine("Nachname angeben..");
        customer.LastName = Console.ReadLine();
        Console.WriteLine("Adresse angeben..");
        customer.Address = Console.ReadLine();
        return customer;
    }

    private static Car CreateCar()
    {
        Car car = new Car();
        car.Id = carId;
        carId++;

        Console.WriteLine("Hersteller angeben...");
        car.Manufacturer = Console.ReadLine();
        Console.WriteLine("Modell angeben..");
        car.Model = Console.ReadLine();

        return car;
    }
}

