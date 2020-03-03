using System;
using Tabuleiros;

namespace Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
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

        public void RealizaJogada(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void ValidarPosicaoOrigem(PosicaoTabuleiro pos)
        {
            if (Tabuleiro.Peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");

            if (JogadorAtual != Tabuleiro.Peca(pos).Cor)
                throw new TabuleiroException("A peça de origem escohida não é sua!");

            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void ValidarPosicaoDestino(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            if (!Tabuleiro.Peca(origem).PodeMoverParaPosicao(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }

        public void mudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
                JogadorAtual = Cor.Preto;
            else
                JogadorAtual = Cor.Branco;
        }

        private void colocarPecas()
        {
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('C', 1).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('C', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('D', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('E', 2).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Branco), new PosicaoXadrez('E', 1).ToPosicao());
            Tabuleiro.PosicionarPeca(new Rei(Tabuleiro, Cor.Branco), new PosicaoXadrez('D', 1).ToPosicao());

            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('C', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('C', 8).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('D', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('E', 7).ToPosicao());
            Tabuleiro.PosicionarPeca(new Torre(Tabuleiro, Cor.Preto), new PosicaoXadrez('E', 8).ToPosicao());
            Tabuleiro.PosicionarPeca(new Rei(Tabuleiro, Cor.Preto), new PosicaoXadrez('D', 8).ToPosicao());
        }
    }
}
