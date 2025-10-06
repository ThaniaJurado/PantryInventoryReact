namespace FoodInventorySystem.Server
{
    public class Inventory
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }


        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string MeasurementUnit { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
