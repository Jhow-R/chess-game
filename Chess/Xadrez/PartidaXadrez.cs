using System;
using Tabuleiros;

namespace Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private  set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }

        public void ExecutaMovimento(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca capturada = tab.RetirarPeca(destino);
            tab.PosicionarPeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.PosicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('C', 1).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('C', 2).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('D', 2).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('E', 2).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('E', 1).ToPosicao());
            tab.PosicionarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('D', 1).ToPosicao());

            tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('C', 7).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('C', 8).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('D', 7).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('E', 7).ToPosicao());
            tab.PosicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('E', 8).ToPosicao());
            tab.PosicionarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('D', 8).ToPosicao());
        }
    }
}
