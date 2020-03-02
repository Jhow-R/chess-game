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
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    PosicaoTabuleiro origem = Tela.LerPosicaoXadrez().ToPosicao();

                    Console.Write("Destino: ");
                    PosicaoTabuleiro destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                        
                }               
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
