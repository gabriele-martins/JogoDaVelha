using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using JogoDaVelha.Repository;

namespace JogoDaVelha.Services
{
    public class Ranking
    {
        private static List<Jogador> ranking = Json.jogadores.OrderBy(jogador => jogador.Pontos).ToList();
        public static void AtualizarRanking()
        {
            ranking = Json.jogadores.OrderBy(jogador => jogador.Pontos).ThenBy(jogador => jogador.Vitorias).ThenByDescending(jogador => jogador.Derrotas).ToList();
        }
        public static void MostrarRanking()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tRanking de Jogadores");
            Console.ResetColor();
            AtualizarRanking();
            for (int i=ranking.Count-1, j=1; i>=0; i--, j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"\n\t{j}º");
                Console.ResetColor();
                Console.WriteLine($" {ranking[i].Nickname}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"\tPontos:");
                Console.ResetColor();
                Console.WriteLine($" {ranking[i].Pontos}");
            }
            Menu.VoltarMainMenu();
        }
    }
}
