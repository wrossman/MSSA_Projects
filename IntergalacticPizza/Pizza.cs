    public class Pizza
    {
        public Pizza(string type, int price)
        {
            Type = type;
            Price = price;
        }

        public string Type { get; set; } = "";
        public int Price { get; set; } = 0;
        public int Count { get; set; } = 1;

    }