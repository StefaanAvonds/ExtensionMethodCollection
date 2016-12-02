using ExtensionMethodCollection.Extensions;
using System;

namespace ExtensionMethodCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 98413518;
            int length = temp.IntLength();

            Console.WriteLine($"The integer-value {temp} contains in total {length} amount of characters.");
            Console.ReadLine();
        }
    }
}
