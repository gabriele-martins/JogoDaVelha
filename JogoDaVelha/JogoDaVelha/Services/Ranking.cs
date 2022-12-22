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
            ranking = Json.jogadores.OrderBy(jogador => jogador.Pontos).ToList();
        }
        public static void MostrarRanking()
        {
            Console.Clear();
            Console.WriteLine("\n\tRanking de Jogadores");
            AtualizarRanking();
            for (int i=ranking.Count-1, j=1; i>=0; i--, j++)
            {
                Console.WriteLine($"\n\t{j}º {ranking[i].Nickname}");
                Console.WriteLine($"\tPontos: {ranking[i].Pontos}");
            }
            Menu.VoltarMainMenu();
        }
    }
}
