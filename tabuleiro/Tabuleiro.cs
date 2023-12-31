﻿

namespace tabuleiro {
    class Tabuleiro {
        //atributos
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        //construtores
        public Tabuleiro(int linhas,int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas,colunas];
        }
        public Peca peca(int linha,int coluna) {
            return pecas[linha,coluna];
        }
        public Peca peca(Posicao pos) {
            return pecas[pos.linha,pos.coluna];
        }
        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        //Metodo para adicionar peça
        public void colocarPeca(Peca p,Posicao pos) {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha,pos.coluna] = p;
            p.posicao = pos;
        }
        // Metodo para retirar peça
        public Peca retirarPeca(Posicao pos) {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha,pos.coluna] = null;
            return aux;
        } //Validação de posição
        public bool posicaovalida(Posicao pos) {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos) {
            if (!posicaovalida(pos))
            {
                throw new TabuleiroException("Posição Invalida!");

            }
        }
    }
}
    

