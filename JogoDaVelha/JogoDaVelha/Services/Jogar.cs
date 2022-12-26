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
        private static List<string> posicoes = new List<string>();
        public static void SelecionarJogadores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tJogador 1: ");
            Console.ResetColor();
            string jogador1 = Console.ReadLine();
            jogador1 = Menu.NaoExisteJogador(jogador1);
            Jogador1 = jogador1;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tJogador 2: ");
            Console.ResetColor();
            string jogador2 = Console.ReadLine();
            jogador2 = Menu.NaoExisteJogador(jogador2);
            Jogador2 = jogador2;
        }
        public static string[,] ChamarTabuleiro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tDigite o tamanho do tabuleiro (3 a 10): ");
            Console.ResetColor();
            Tamanho = int.Parse(Console.ReadLine());
            while (Tamanho < 3 || Tamanho > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tTamanho incorreto. Digite o tamanho novamente: ");
                Console.ResetColor();
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
                        posicao = PegarPosicao(Jogador1,"X");
                        Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "X");
                        if(Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "X"))
                        {
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("\n\tVencedor:");
                            Console.ResetColor();
                            Console.WriteLine($" {Jogador1}");
                            Console.Write($"\t{Jogador1}");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(" recebe +3 pontos");
                            Console.ResetColor();
                            Console.Write($"\t{Jogador2}");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(" não recebe pontos");
                            Console.ResetColor();
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
                        posicao = PegarPosicao(Jogador2,"O");
                        Tabuleiro.AlterarTabuleiro(posicao, Tamanho, tabuleiro, "O");
                        if (Tabuleiro.VerificarTabuleiro(posicao, Tamanho, tabuleiro, "O"))
                        {
                            Tabuleiro.MostrarTabuleiro(tabuleiro, Tamanho);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("\n\tVencedor:");
                            Console.ResetColor();
                            Console.WriteLine($" {Jogador2}");
                            Console.Write($"\t{Jogador2}");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(" recebe +3 pontos");
                            Console.ResetColor();
                            Console.Write($"\t{Jogador1}");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine(" não recebe pontos");
                            Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\n\tEmpate: Deu velha.");
                        Console.ResetColor();
                        Console.Write($"\t{Jogador1}");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(" recebe +1 ponto");
                        Console.ResetColor();
                        Console.Write($"\t{Jogador2}");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(" recebe +1 ponto");
                        Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tO tamanho deve ser um número inteiro.");
                Console.ResetColor();
                Menu.VoltarMainMenu();
            }
        }
        public static string PegarPosicao(string jogador, string valor)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\n\tVez de");
            Console.ResetColor();
            Console.Write($" {jogador}");
            if (valor == "X") 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" ({valor})");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" ({valor})");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tDigite a posição: ");
            Console.ResetColor();
            string posicao = Console.ReadLine();
            int number;
            while (posicoes.Contains(posicao) || !int.TryParse(posicao, out number) || number < 1 || number > Tamanho * Tamanho)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tPosição incorreta. Digite a posição novamente: ");
                Console.ResetColor();
                posicao = Console.ReadLine();
            }
            posicoes.Add(posicao);
            return posicao;
        }
    }
}
