using System;


using tabuleiro;
using xadrez;

namespace xadrez_console {

    class Program{
        static void Main(string[] args){
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                        Console.Write("Origem : ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] possicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, possicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino : ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);
                        partida.executaMovimento(origem, destino);
                    }
                    catch (TabuleiroException e) { 
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

               





                
            }
            catch (TabuleiroException e) { 
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
