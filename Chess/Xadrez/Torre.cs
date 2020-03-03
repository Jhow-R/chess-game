using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiros;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(PosicaoTabuleiro pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            PosicaoTabuleiro pos = new PosicaoTabuleiro(0, 0);

            // Acima da torre
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            // Abaixo da torre
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            // Direita da torre
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // Esquerda da torre
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return matriz;
        }
    }
}
