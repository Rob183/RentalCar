using Newtonsoft.Json;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Daten
{
    internal class CustomerDB
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer()
        {
            Customer customer = new Customer(GetAmountItems() + 1);
            Console.WriteLine("Vorname angeben...");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Nachname angeben..");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Adresse angeben..");
            customer.Address = Console.ReadLine();

            customers.Add(customer);
        }
        public void ChangeCustomer()
        {
            Console.WriteLine("Bitte Id des zu ändernden Gastes eingeben");
            int id = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
            var res = CheckIfIdInRange(id);

            if (res == true)
            {
                Customer customer = GetCustomer(id - 1); //Gast mit passender ID wählen
                Console.WriteLine("Vorname angeben...");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Nachname angeben..");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Adresse angeben..");
                customer.Address = Console.ReadLine();
            }
        }

        public void ShowAllCustomers()
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
        }

        public Customer GetCustomer(int id)
        {
            return customers[id];
        }

        public void DeleteCustomer()
        {
            Console.WriteLine("Bitte Id des zu löschenden Kunden angeben");
            int id = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
            var res = CheckIfIdInRange(id);

            if (res == true)
            {
                Customer cust = GetCustomer(id - 1); //Auto mit passender ID wählen
                customers.Remove(cust);
            }
        }

        public bool CheckIfIdInRange(int id)
        {
            if (id >= GetAmountItems() + 1) // checken ob keine zu hohe ID eingegeben wurde
            {
                Console.WriteLine("ID nicht vorhanden");
                return false;
            }
            else { return true; }
        }

        public int GetAmountItems() { return customers.Count; }

        public List<Customer> GetCustomers() { return customers; }

        public void saveData()
        {
            string json = JsonConvert.SerializeObject(customers);
            File.WriteAllText(@".\Customersdata.json", json);
        }

        internal void AddCustomerToList(Customer customer)
        {
            customers.Add(customer);
        }
    }
}
