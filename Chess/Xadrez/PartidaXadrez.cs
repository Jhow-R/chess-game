using System.Collections.Generic;
using Chess.Xadrez;
using Tabuleiros;

namespace Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool EstaTerminada { get; private set; }
        public bool EmXeque { get; private set; }
        public HashSet<Peca> pecas;
        public HashSet<Peca> capturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            EstaTerminada = false;
            EmXeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutarMovimento(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarMovimentos();
            Peca capturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.PosicionarPeca(p, destino);

            if (capturada != null)
                capturadas.Add(capturada);

            return capturada;
        }

        public void DesfazMovimento(PosicaoTabuleiro origem, PosicaoTabuleiro destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarMovimentos();

            if (pecaCapturada != null)
            {
                Tabuleiro.PosicionarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            Tabuleiro.PosicionarPeca(p, origem);
        }

        public void RealizarJogada(PosicaoTabuleiro origem, PosicaoTabuleiro destino)
        {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (EstaEmXeque(Adversario(JogadorAtual)))
                EmXeque = true;
            else
                EmXeque = false;

            if (TesteXequeMate(Adversario(JogadorAtual)))
                EstaTerminada = true;
            else
            {
                Turno++;
                MudarJogador();
            }
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

        public void MudarJogador()
        {
            JogadorAtual = (JogadorAtual == Cor.Branco) ? Cor.Preto : Cor.Branco;
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

        private Cor Adversario(Cor cor)
        {
            return (cor == Cor.Branco) ? Cor.Preto : Cor.Branco;
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                    return peca;
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);

            if (rei == null)
            {
                throw new TabuleiroException($"Não tem rei da cor {cor} no tabuleiro!");
            }

            foreach (Peca peca in PecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }

            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
                return false;

            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            PosicaoTabuleiro origem = peca.Posicao;
                            PosicaoTabuleiro destino = new PosicaoTabuleiro(i, j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        private void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.PosicionarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('A', 1, new Torre(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('B', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('C', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('D', 1, new Dama(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('E', 1, new Rei(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('F', 1, new Bispo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('G', 1, new Cavalo(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('H', 1, new Torre(Tabuleiro, Cor.Branco));

            ColocarNovaPeca('A', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('B', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('C', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('D', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('E', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('F', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('G', 2, new Peao(Tabuleiro, Cor.Branco));
            ColocarNovaPeca('H', 2, new Peao(Tabuleiro, Cor.Branco));

            ColocarNovaPeca('A', 8, new Torre(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('B', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('C', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('D', 8, new Dama(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('E', 8, new Rei(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('F', 8, new Bispo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('G', 8, new Cavalo(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('H', 8, new Torre(Tabuleiro, Cor.Preto));

            ColocarNovaPeca('A', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('B', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('C', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('D', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('E', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('F', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('G', 7, new Peao(Tabuleiro, Cor.Preto));
            ColocarNovaPeca('H', 7, new Peao(Tabuleiro, Cor.Preto));
        }
    }
}
