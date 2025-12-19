
using System.Text;

System.Console.WriteLine("Please enter anything...");

string input = Console.ReadLine() ?? "";

StringBuilder sb = new();

for (int i = input.Length - 1; i >= 0; i--)
{
    sb.Append(input[i]);
}

System.Console.WriteLine(sb.ToString());