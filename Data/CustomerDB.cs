using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RentalCar.Models;

namespace RentalCar.Daten
{
    internal class CustomerDB
    {
        private List<Customer> customers = new List<Customer>();

        internal void AddCustomer()
        {
            Customer customer = new Customer(GetAmountItems() + 1);
            Console.WriteLine("Vorname angeben...");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Nachname angeben..");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Adresse angeben..");
            customer.Address = Console.ReadLine();

            customers.Add(customer);

            AddToCloud(customer);
        }

        private void AddToCloud(Customer customer)
        {
            // Verbindungszeichenfolge zur MongoDB Atlas-Datenbank -> Erstellen Sie eine Instanz des MongoClient -> Datenbank
            var client = new MongoClient("mongodb+srv://RentalCar:DSoh8IQ54Elj2myr@cluster0.xmlqw5t.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("RentalCar");

            // Wählen Sie die Sammlung aus
            var collection = database.GetCollection<BsonDocument>("customers");

            // Fügen Sie die Liste von Objekten in die MongoDB-Sammlung ein
            collection.InsertOne(customer.ToBsonDocument());
        }

        internal void ChangeCustomer()
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

        internal void ShowAllCustomers()
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
        }

        internal Customer GetCustomer(int id) => customers[id];

        internal void DeleteCustomer()
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

        internal bool CheckIfIdInRange(int id)
        {
            if (id >= GetAmountItems() + 1) // checken ob keine zu hohe ID eingegeben wurde
            {
                Console.WriteLine("ID nicht vorhanden");
                return false;
            }
            else { return true; }
        }

        internal int GetAmountItems() { return customers.Count; }

        internal List<Customer> GetCustomers() { return customers; }

        internal void AddCustomerToList(Customer customer) => customers.Add(customer);

        /*internal void saveData()
      {
          string json = JsonConvert.SerializeObject(customers);
          File.WriteAllText(@".\Customersdata.json", json);
      }*/
    }
}
