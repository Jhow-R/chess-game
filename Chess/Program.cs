using System;
using Tabuleiros;
using Xadrez;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.PosicionarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.PosicionarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.PosicionarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
