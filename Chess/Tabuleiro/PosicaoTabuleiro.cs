
namespace Tabuleiros
{
    class PosicaoTabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public PosicaoTabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha + ", "
                + Coluna;
        }
    }
}
