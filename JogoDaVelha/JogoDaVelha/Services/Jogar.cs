using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using JogoDaVelha.Repository;

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
            while (Tamanho < 3 || Tamanho > 10)
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
            try
            {
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
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.WriteLine($"\n\tVencedor: {Jogador1}.");
                            Console.WriteLine($"\t{Jogador1} recebe +3 pontos.");
                            Console.WriteLine($"\t{Jogador2} não recebe pontos.");
                            Json.jogadores.Find(player => player.Nickname == Jogador1).Partidas += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador2).Partidas += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador1).Pontos += 3;
                            Json.jogadores.Find(player => player.Nickname == Jogador1).Vitorias += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador2).Derrotas += 1;
                            Ranking.AtualizarRanking();
                            Json.Serializar();
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
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.WriteLine($"\n\tVencedor: {Jogador2}.");
                            Console.WriteLine($"\t{Jogador2} recebe +3 pontos.");
                            Console.WriteLine($"\t{Jogador1} não recebe pontos.");
                            Json.jogadores.Find(player => player.Nickname == Jogador1).Partidas += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador2).Partidas += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador2).Pontos += 3;
                            Json.jogadores.Find(player => player.Nickname == Jogador2).Vitorias += 1;
                            Json.jogadores.Find(player => player.Nickname == Jogador1).Derrotas += 1;
                            Ranking.AtualizarRanking();
                            Json.Serializar();
                            Menu.VoltarMainMenu();
                            break;
                        }
                        vez++;
                    }
                    if (Tabuleiro.VerificarVelha(posicao, Tamanho, tabuleiro))
                    {
                        Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                        Console.WriteLine("\n\tEmpate: Deu velha.");
                        Console.WriteLine($"\t{Jogador1} recebe +1 ponto.");
                        Console.WriteLine($"\t{Jogador2} recebe +1 ponto.");
                        Json.jogadores.Find(player => player.Nickname == Jogador1).Partidas += 1;
                        Json.jogadores.Find(player => player.Nickname == Jogador2).Partidas += 1;
                        Json.jogadores.Find(player => player.Nickname == Jogador1).Pontos += 1;
                        Json.jogadores.Find(player => player.Nickname == Jogador2).Pontos += 1;
                        Json.jogadores.Find(player => player.Nickname == Jogador1).Empates += 1;
                        Json.jogadores.Find(player => player.Nickname == Jogador2).Empates += 1;
                        Ranking.AtualizarRanking();
                        Json.Serializar();
                        Menu.VoltarMainMenu();
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("\n\tO tamanho deve ser um número inteiro.");
                Menu.VoltarMainMenu();
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
