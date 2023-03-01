namespace RentalCar.Models
{
    public class Car
    {
        public Car(int id)
        {
            Id = id;
            Available = true;
        }
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public bool Available { get; set; }
        public int? DistanceKm { get; set; }
        public override string ToString() => $"Id: {Id}; "+
            System.Environment.NewLine + $"Hersteller: {Manufacturer};" +
            System.Environment.NewLine + $" Model: {Model};" +
            System.Environment.NewLine + $" KM: {DistanceKm} ; " +
            System.Environment.NewLine + $" Verfügbar: {Available}";
    }
}
