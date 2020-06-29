using Tabuleiros;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor) 
        {
            this.partida = partida;
        }

        private bool PodeMover(PosicaoTabuleiro pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TorrePodeFazerRoque(PosicaoTabuleiro pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            PosicaoTabuleiro pos = new PosicaoTabuleiro(0, 0);

            // Acima do rei
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Nordeste do rei
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Direita do rei
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Sudeste do rei
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Sudoeste do rei
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Abaixo do rei
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Esquerda do rei
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Noroeste do rei
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Jogada especial: Roque
            if (QtdMovimentos == 0 && !partida.EmXeque)
            {
                // Roque Pequeno
                PosicaoTabuleiro posicaoTorre1 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna+3);
                if (TorrePodeFazerRoque(posicaoTorre1))
                {
                    PosicaoTabuleiro p1 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna + 1);
                    PosicaoTabuleiro p2 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Roque Grande
                PosicaoTabuleiro posicaoTorre2 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna-4);
                if (TorrePodeFazerRoque(posicaoTorre2))
                {
                    PosicaoTabuleiro p1 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna - 1);
                    PosicaoTabuleiro p2 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna - 2);
                    PosicaoTabuleiro p3 = new PosicaoTabuleiro(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
