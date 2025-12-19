namespace PizzaSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Dictionary<string, int> pizzaPrice = new()
                {
                    { "cheese", 10 },
                    { "meat", 15 },
                    { "veggie", 12 },
                    { "bbq", 18 },
                };

                Dictionary<string, int> locations = new()
                {
                    { "earth", 5 },
                    { "mars", 10},
                    { "jupiter", 15 },
                    { "venus", 8 }
                };

                HashSet<string> orderIncludes = [];

                List<Pizza> myOrderList = [];

                int totalPizzas = 0;
                int subtotal = 0;
                float discount = 0;
                string readResult;

                do
                {
                    Utility.PrintHello();
                    readResult = Console.ReadLine() ?? "";
                    readResult = readResult.ToLower();
                } while (!locations.ContainsKey(readResult));

                Customer customer = new(readResult, locations[readResult]);

                while (true)
                {
                    Utility.PrintMenu(pizzaPrice, myOrderList);
                    readResult = Console.ReadLine() ?? "";
                    readResult = readResult.ToLower();
                    if (readResult == "done")
                        break;
                    if (pizzaPrice.ContainsKey(readResult))
                    {
                        if (orderIncludes.Contains(readResult))
                        {
                            foreach (Pizza item in myOrderList)
                            {
                                if (item.Type == readResult)
                                    item.Count++;
                            }
                        }
                        else
                        {
                            myOrderList.Add(new Pizza(readResult, pizzaPrice[readResult]));
                            orderIncludes.Add(readResult);
                        }
                        totalPizzas++;
                        subtotal += pizzaPrice[readResult];
                    }
                }
                ;

                if (totalPizzas > 2)
                    discount = subtotal * .10f;

                float totalCost = subtotal + customer.DeliveryFee - discount;

                Utility.PrintFinalOrder(customer, myOrderList, subtotal, discount, totalCost);

            }
        }
    }
}