using System;
using Tabuleiros;

namespace Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private  set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }

        public void ExecutaMovimento(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca capturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.PosicionarPeca(p, destino);
        }

        private void colocarPecas()
        {
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('C', 1).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('C', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('D', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('E', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('E', 1).ToPosicao());
            Tabuleiro.PosicionarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('D', 1).ToPosicao());
            
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('C', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('C', 8).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('D', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('E', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('E', 8).ToPosicao());
            Tabuleiro.PosicionarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('D', 8).ToPosicao());
        }
    }
}
