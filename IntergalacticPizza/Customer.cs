namespace PizzaSpace
{
    public class Customer
    {
        public Customer(string location, int fee)
        {
            Location = location;
            DeliveryFee = fee;
        }
        public string Name { get; set; } = "UNKNOWN";
        public string Location { get; set; } = "";
        public int DeliveryFee { get; set; } = 0;


    }
}