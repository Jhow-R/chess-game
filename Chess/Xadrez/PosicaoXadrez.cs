using Tabuleiros;

namespace Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }


        public PosicaoXadrez(char coluna, int linha)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public PosicaoTabuleiro ToPosicao()
        {
            return new PosicaoTabuleiro(8-Linha, Coluna - 'A');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
