using System.Collections.Generic;
using Tabuleiros;

namespace Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> pecas;
        public HashSet<Peca> capturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca capturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.PosicionarPeca(p, destino);

            if (capturada != null)
                capturadas.Add(capturada);


        }

        public void RealizaJogada(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
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

        public void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
                JogadorAtual = Cor.Preto;
            else
                JogadorAtual = Cor.Branco;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca item in capturadas)
            {
                if (item.Cor == cor)
                    aux.Add(item);
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca item in pecas)
            {
                if (item.Cor == cor)
                    aux.Add(item);
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.PosicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('C', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('C', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('D', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('E', 2, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('E', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('D', 1, new Rei(Tabuleiro, Cor.Branco));

            ColocarNovaPeca('C', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('C', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('D', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('E', 7, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('E', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('D', 8, new Rei(Tabuleiro, Cor.Preto));

        }
    }
}
