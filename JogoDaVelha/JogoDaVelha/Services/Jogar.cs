using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;

namespace JogoDaVelha.Services
{
    public class Jogar
    {
        private static string Jogador1;
        private static string Jogador2;
        private static int Tamanho;
        public static void SelecionarJogadores()
        {
            Console.Clear();
            Console.Write("\n\tJogador 1: ");
            string jogador1 = Console.ReadLine();
            jogador1 = Menu.NaoExisteJogador(jogador1);
            Jogador1 = jogador1;
            Console.Write("\n\tJogador 2: ");
            string jogador2 = Console.ReadLine();
            jogador2 = Menu.NaoExisteJogador(jogador2);
            Jogador2 = jogador2;
        }
        public static string[,] ChamarTabuleiro()
        {
            Console.Clear();
            Console.Write("\n\tDigite o tamanho do tabuleiro (3 a 10): ");
            Tamanho = int.Parse(Console.ReadLine());
            while(Tamanho<3 || Tamanho > 10)
            {
                Console.Write("\n\tTamanho incorreto. Digite o tamanho novamente: ");
                Tamanho = int.Parse(Console.ReadLine());
            }
            string[,] tabuleiro = Tabuleiro.GerarTabuleiro(Tamanho);
            return tabuleiro;
        }
        public static void Jogo()
        {
            SelecionarJogadores();
            string[,] tabuleiro = ChamarTabuleiro();
            string posicao;
            int vez = 1;
            while(true)
            {
                Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                if (vez%2!=0)
                {
                    posicao = PegarPosicao(Jogador1);
                    Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "X");
                    if(Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "X"))
                    {
                        Console.WriteLine("Vencedor jogador 1");
                        Menu.VoltarMainMenu();
                        break;
                    }
                    vez++;
                }
                else
                {
                    posicao = PegarPosicao(Jogador2);
                    Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "O");
                    if (Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "O"))
                    {
                        Console.WriteLine("Vencedor jogador 2");
                        Menu.VoltarMainMenu();
                        break;
                    }
                    vez++;
                }
            }
        }
        public static string PegarPosicao(string jogador)
        {
            Console.WriteLine($"\n\tVez de {jogador}.");
            Console.Write("\n\tDigite a posição: ");
            string posicao = Console.ReadLine();
            while (int.Parse(posicao) < 1 || int.Parse(posicao) > Tamanho * Tamanho)
            {
                Console.Write("\n\tPosição incorreta. Digite a posição novamente: ");
                posicao = Console.ReadLine();
            }
            return posicao;
        }
    }
}
