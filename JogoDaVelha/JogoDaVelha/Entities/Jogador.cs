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
            Console.WriteLine("\n\tDetalhes de um Jogador.");
            string nickname = Menu.GetNickname();
            while (!Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                nickname = Menu.GetNickname();
            }
            Console.WriteLine($"\n\tPartidas: {Json.jogadores.Find(player => player.Nickname == nickname).Partidas}");
            Console.WriteLine($"\tPontos: {Json.jogadores.Find(player => player.Nickname == nickname).Pontos}");
            Console.WriteLine($"\tVitórias: {Json.jogadores.Find(player => player.Nickname == nickname).Vitorias}");
            Console.WriteLine($"\tDerrotas: {Json.jogadores.Find(player => player.Nickname == nickname).Derrotas}");
            Console.WriteLine($"\tEmpates: {Json.jogadores.Find(player => player.Nickname == nickname).Empates}");
            Menu.VoltarMainMenu();
        }
    }
}