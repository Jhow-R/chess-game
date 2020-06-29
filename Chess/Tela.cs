using System;
using System.Collections.Generic;
using Tabuleiros;
using Xadrez;

namespace Game
{
    class Tela
    {
        public static void ImprimirPartida(PartidaXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);

            if (!partida.EstaTerminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                if (partida.EmXeque)
                    Console.WriteLine("XEQUE!");
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");

            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preto));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca item in conjunto)
                Console.Write(item + " ");
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoePossiveis)
        {

            ConsoleColor corInicial = Console.BackgroundColor;
            ConsoleColor corAlterada = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                        Console.BackgroundColor = corAlterada;
                    else
                        Console.BackgroundColor = corInicial;

                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = corInicial;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = corInicial;
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
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor corInicial = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corInicial;
                }
                Console.Write(" ");
            }
        }
    }
}
