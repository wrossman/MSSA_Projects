namespace PizzaSpace
{
    public class Utility
    {
        public static void PrintHello()
        {
            Console.Clear();
            System.Console.WriteLine("Hello, Welcome to Intergalactic Pizza!");
            System.Console.WriteLine();
            System.Console.WriteLine("Where are you ordering from?");
            System.Console.WriteLine("(Valid locations are Earth, Mars, Jupiter, and Venus)");
            System.Console.WriteLine();
        }

        public static void PrintMenu(Dictionary<string, int> pizzaList, List<Pizza> myOrderList)
        {
            int count = 1;
            Console.Clear();
            System.Console.WriteLine("What kind of pizza would you like?");
            System.Console.WriteLine();
            foreach (KeyValuePair<string, int> item in pizzaList)
            {
                System.Console.WriteLine($"{count}. {item.Key}");
                count++;
            }
            System.Console.WriteLine();
            System.Console.WriteLine("If you are finished with your order, please enter \"done\"...");
            System.Console.WriteLine();
            System.Console.WriteLine($"Current order: ");
            System.Console.WriteLine();
            foreach (Pizza item in myOrderList)
            {
                System.Console.WriteLine($"{item.Count} x {item.Type} @ ${item.Price} Total: {item.Count * item.Price:C2}");
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the name of the item you would like to order. If finished, enter \"done\".");
        }

        public static void PrintFinalOrder(Customer customer, List<Pizza> myOrderList, int subtotal, float discount, float totalCost)
        {
            System.Console.WriteLine($"Final order to {customer.Location}");
            System.Console.WriteLine();
            foreach (Pizza item in myOrderList)
            {
                System.Console.WriteLine($"{item.Count} x {item.Type} @ ${item.Price} Total: {item.Count * item.Price:C2}");
            }
            System.Console.WriteLine($"Subtotal: {subtotal:C2}");
            System.Console.WriteLine($"Discount: {discount:C2}");
            System.Console.WriteLine($"Delivery Fee: {customer.DeliveryFee:C2}");
            System.Console.WriteLine($"Total Cost: {totalCost:C2}");
            Console.Read();
        }

    }
}