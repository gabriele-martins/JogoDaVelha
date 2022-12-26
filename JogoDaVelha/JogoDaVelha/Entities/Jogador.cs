using JogoDaVelha.Controllers;
using JogoDaVelha.Repository;

namespace JogoDaVelha.Entities
{
    public class Jogador
    {
        public string Nickname { get; set; }
        public int Partidas { get; set; }
        public int Pontos { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public Jogador(string nickname)
        {
            Nickname = nickname;
            Partidas = 0;
            Pontos = 0;
            Vitorias = 0;
            Derrotas = 0;
            Empates = 0;
        }
        public static void DetalharJogador()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tDetalhes de um Jogador.");
            Console.ResetColor();
            string nickname = Menu.GetNickname();
            while (!Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                Console.ResetColor();
                nickname = Menu.GetNickname();
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\n\tPartidas:");
            Console.ResetColor();
            Console.WriteLine($" {Json.jogadores.Find(player => player.Nickname == nickname).Partidas}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\tPontos:");
            Console.ResetColor();
            Console.WriteLine($" {Json.jogadores.Find(player => player.Nickname == nickname).Pontos}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\tVitórias:");
            Console.ResetColor();
            Console.WriteLine($" {Json.jogadores.Find(player => player.Nickname == nickname).Vitorias}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\tDerrotas:");
            Console.ResetColor();
            Console.WriteLine($" {Json.jogadores.Find(player => player.Nickname == nickname).Derrotas}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"\tEmpates:");
            Console.ResetColor();
            Console.WriteLine($" {Json.jogadores.Find(player => player.Nickname == nickname).Empates}");
            Menu.VoltarMainMenu();
        }
    }
}