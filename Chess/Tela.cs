using System;
using Tabuleiros;
using Xadrez;

namespace Chess
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write("  " + (8 - i) + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                       ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("    A B C D E F G H \n");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string aux = Console.ReadLine().ToUpper();
            char coluna = aux[0];
            int linha = int.Parse(aux[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        private static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
                Console.Write(peca);
            else
            {
                ConsoleColor initialColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = initialColor;
            }

        }
    }
}
