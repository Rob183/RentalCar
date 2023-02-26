using Newtonsoft.Json;
using RentalCar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RentalCar.Daten
{
    public class CarDB
    {
        private List<Car> cars = new List<Car>();

        public void AddCar()
        {
            Car car = new Car(GetAmountItems() + 1);
            Console.WriteLine("Hersteller angeben...");
            car.Manufacturer = Console.ReadLine();
            Console.WriteLine("Modell angeben..");
            car.Model = Console.ReadLine();
            Console.WriteLine("KM angeben..");
            car.DistanceKm = Convert.ToInt32(Console.ReadLine());
            cars.Add(car);
        }

        public Car GetCar(int id)
        {
            return cars[id];
        }

        internal int GetAmountItems() { return cars.Count; }

        public List<Car> GetCars() { return cars; }

        internal void DeleteCar()
        {
            Console.WriteLine("Bitte Id des Fahrzeugs angeben");
            int id = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
            var res = CheckIfIdInRange(id);

            if (res == true)
            {
                Car car = GetCar(id - 1); //Auto mit passender ID wählen
                cars.Remove(car);
            }
        }

        internal void ChangeCar()
        {
            Console.WriteLine("Bitte Id des Fahrzeugs angeben");
            int id = Convert.ToInt32(Console.ReadLine()); // Eingabe von string ID in int umwandeln
            var res = CheckIfIdInRange(id);

            if (res == true)
            {
                Car car = GetCar(id - 1); //Auto mit passender ID wählen
                Console.WriteLine("Hersteller angeben...");
                car.Manufacturer = Console.ReadLine();
                Console.WriteLine("Modell angeben..");
                car.Model = Console.ReadLine();
                Console.WriteLine("KM angeben..");
                car.DistanceKm = Convert.ToInt32(Console.ReadLine());
            }
        }

        internal bool CheckIfIdInRange(int id)
        {
            if (id >= GetAmountItems() +1) // checken ob keine zu hohe ID eingegeben wurde
            {
                Console.WriteLine("ID nicht vorhanden");
                return false;
            }
            else { return true; }
        }

        internal void ShowAllCars()
        {
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }

        internal void ShowUnavailableCars()
        {
            List<Car> result = cars.Where(o => o.Available == false).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        internal void saveData()
        {
            string json = JsonConvert.SerializeObject(cars);
            File.WriteAllText(@".\Cardata.json", json);
        }

        internal void AddCarsToList(Car car)
        {
            cars.Add(car);
        }
    }


}
