using System;
using Tabuleiro;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro.Tabuleiro tab = new Tabuleiro.Tabuleiro(8,8);           

            Console.WriteLine(tab);


            Console.ReadLine();
        }
    }
}
