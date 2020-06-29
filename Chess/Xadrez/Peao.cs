using Tabuleiros;
using Xadrez;

namespace Chess.Xadrez
{
    class Peao : Peca
    {
        //private PartidaXadrez partida;

        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) {}

        private bool ExisteInimigo(PosicaoTabuleiro pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool EstaLivre(PosicaoTabuleiro pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            PosicaoTabuleiro pos = new PosicaoTabuleiro(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && EstaLivre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                PosicaoTabuleiro p2 = new PosicaoTabuleiro(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && EstaLivre(p2) && Tabuleiro.PosicaoValida(pos) && EstaLivre(pos) && QtdMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && EstaLivre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                PosicaoTabuleiro p2 = new PosicaoTabuleiro(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && EstaLivre(p2) && Tabuleiro.PosicaoValida(pos) && EstaLivre(pos) && QtdMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;
                
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
