﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
    class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca RetornaPeca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public Peca RetornaPeca(Posicao pos) {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nesta posição !");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;

        }

        public Peca RetirarPeca (Posicao pos) {
            if(RetornaPeca(pos) == null) {
                return null;
            }
            Peca peca = RetornaPeca(pos);
            peca.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return peca;
        }

        public bool PosicaoValida(Posicao pos) {
            if(pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida !!");
            }
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return RetornaPeca(pos) != null;
        }
    }
}
