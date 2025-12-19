namespace Bottles
{
    class Program
    {
        public static void Main(string[] args)
        {

            for (int i = 99; i > 2; i--)
            {
                SingSong(i);
            }

            System.Console.WriteLine($"2 more bottles of beer on the wall, 2 more bottles of beer.");
            System.Console.WriteLine($"Take one down, pass it around, 1 more bottle of beer on the wall.");
            System.Console.WriteLine();

            System.Console.WriteLine($"1 more bottle of beer on the wall, 1 more bottle of beer.");
            System.Console.WriteLine($"Take one down, pass it around, no more bottles of beer on the wall.");
            System.Console.WriteLine();

            System.Console.WriteLine("No more bottles of beer on the wall, no more bottles of beer.");
            System.Console.WriteLine("Go to the store and buy some more, 99 bottles of beer on the wall.");
            System.Console.WriteLine();


            System.Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            string SingSong(int bottles)
            {
                return $"{bottles} more bottles of beer on the wall, {bottles} more bottles of beer." +
                        $"Take one down, pass it around, {bottles - 1} more bottles of beer on the wall.\n";
            }
        }
    }
}