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

                tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoTabuleiro(0, 0));
                tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoTabuleiro(1, 3));
                tab.PosicionarPeca(new Rei(tab, Cor.Preta), new PosicaoTabuleiro(0, 2));

                tab.PosicionarPeca(new Rei(tab, Cor.Branca), new PosicaoTabuleiro(3, 5));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            PosicaoXadrez posicao = new PosicaoXadrez('C', 7);

            Console.WriteLine(posicao);
            Console.WriteLine(posicao.ToPosicao());
             */

            Console.ReadLine();
        }
    }
}
