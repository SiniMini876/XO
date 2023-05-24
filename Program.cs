using System;

namespace XO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XO xO = new XO(7);
            int player = 1;
            Console.Clear();
            xO.Print();
            while (xO.Won()[0, 0] == 0)
            {
                Console.WriteLine(player == 1 ? "X's turn" : "O's turn");
                Console.WriteLine("Enter row: ");
                int row = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter column: ");
                int col = int.Parse(Console.ReadLine());

                if (row > xO.GetSize() || row < 1 || col > xO.GetSize() || col < 1)
                {
                    Console.WriteLine($"Input has to be between 1 - {xO.GetSize()}!");
                }
                else
                {
                    while (!xO.Occupy(row - 1, col - 1, player))
                    {
                        Console.Clear();
                        Console.WriteLine("Place is occupied!");
                        xO.Print();
                        Console.WriteLine("Enter row: ");
                        row = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter column: ");
                        col = int.Parse(Console.ReadLine());
                    }
                    player = player == 1 ? 2 : 1;
                    Console.Clear();
                    xO.Print();
                }

            }
            Console.Clear();
            xO.Print(xO.Won());
            Console.WriteLine($"The winner is " + (xO.Won()[0, 0] == 1 ? "X" : xO.Won()[0, 0] == 2 ? "O" : "no one!"));
        }
    }
}
