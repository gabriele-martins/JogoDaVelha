using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using Newtonsoft.Json;

namespace JogoDaVelha.Repository
{
    public class JSON
    {
        private static string path = "Dados.json";

        public static List<Jogador> jogadores = Desserializar();

        public JSON()
        {
            if (!File.Exists(path)) File.Create(path).Close();
        }

        public static void SerializarAdd(Jogador jogador)
        {
            while (jogadores.Any(player => player.Nickname == jogador.Nickname))
            {
                Console.WriteLine("\n\tJogador já cadastrado. Tente novamente.");
                jogador.Nickname = Menu.GetNickname();
            }
            jogadores.Add(jogador);
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, jogadores);
                }
                Console.WriteLine("\n\tJogador cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t{e.Message}");
            }
        }

        public static void SerializarRemove(string nickname)
        {
            while (!jogadores.Any(player => player.Nickname == nickname))
            {
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                nickname = Menu.GetNickname();
            }
            jogadores.RemoveAll(player => player.Nickname == nickname);
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, jogadores);
                }
                Console.WriteLine("\n\tJogador deletado com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t{e.Message}");
            }
        }

        public static List<Jogador> Desserializar()
        {
            List<Jogador> jogadores = new List<Jogador>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();
                    jogadores = JsonConvert.DeserializeObject<List<Jogador>>(jsonString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\t{e.Message}");
            }
            return jogadores;
        }
    }
}
