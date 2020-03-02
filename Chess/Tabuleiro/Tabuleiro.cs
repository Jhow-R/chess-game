
namespace Tabuleiros
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca Peca(PosicaoTabuleiro posicao)
        {
            return pecas[posicao.Linha, posicao.Coluna];
        }

        public bool ExistePeca(PosicaoTabuleiro posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }

        public void PosicionarPeca(Peca peca, PosicaoTabuleiro posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Posição já foi ocupada por uma peça!");
            }
            pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public void ValidarPosicao(PosicaoTabuleiro posicao)
        {
            if (!PosicaoValida(posicao))
                throw new TabuleiroException("Posição inválida!");
        }

        private bool PosicaoValida(PosicaoTabuleiro posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna >= Colunas)
                return false;

            return true;
        }
    }
}
