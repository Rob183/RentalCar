namespace RentalCar.Models
{
    internal class Booking
    {
        public Booking()
        {
            // Konstruktor nimmt aktuelles Datum für das Startdatum
            From = DateTime.Now;
            IsFinished = false;
        }
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public Car? Car { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Price  { get; set; }
        public bool IsFinished { get; set; }
        public int AmountKM { get; set; }

        public override string ToString() => $"Id: {Id};" +
            System.Environment.NewLine + $" Kunde: {Customer};" +
            System.Environment.NewLine + $" Auto: {Car}; " +
            System.Environment.NewLine + $" Kosten: {Price.ToString()} Euro;" +
            System.Environment.NewLine + $" Gebucht von: {From} bis: {To.ToString()}; " +
            System.Environment.NewLine + $" KM gefahren: {AmountKM.ToString()}; " +
            System.Environment.NewLine + $" ABGESCHLOSSEN?: {IsFinished.ToString()}";

    }
}
