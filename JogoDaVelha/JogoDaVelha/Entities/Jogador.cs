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
    }
}