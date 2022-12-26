using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using Newtonsoft.Json;

namespace JogoDaVelha.Repository
{
    public class Json
    {
        private static string path = "Dados.json";

        public static List<Jogador> jogadores = Desserializar();

        public Json()
        {
            if (!File.Exists(path)) File.Create(path).Close();
        }

        public static void Adicionar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tCadastrar novo Jogador.");
            Console.ResetColor();
            string nickname = Menu.GetNickname();
            nickname = Menu.ExisteJogador(nickname);
            Jogador jogador = new Jogador(nickname);
            jogadores.Add(jogador);
            Serializar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tJogador cadastrado com sucesso.");
            Console.ResetColor();
            Menu.VoltarMainMenu();
        }

        public static void Remover()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tDeletar Jogador.");
            Console.ResetColor();
            string nickname = Menu.GetNickname();
            nickname = Menu.NaoExisteJogador(nickname);
            jogadores.RemoveAll(player => player.Nickname == nickname);
            Serializar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tJogador deletado com sucesso.");
            Console.ResetColor();
            Menu.VoltarMainMenu();
        }

        public static void Atualizar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tMudar nickname de Jogador.");
            Console.ResetColor();
            string nickname = Menu.GetNickname();
            nickname = Menu.NaoExisteJogador(nickname);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tDigite o novo Nickname: ");
            Console.ResetColor();
            string novoNick = Console.ReadLine();
            while (jogadores.Any(player => player.Nickname == novoNick))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador já cadastrado. Tente novamente.");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\n\tDigite o novo Nickname: ");
                Console.ResetColor();
                novoNick = Console.ReadLine();
            }
            jogadores.Find(player => player.Nickname == nickname).Nickname = novoNick;
            Serializar();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNickname atualizado com sucesso.");
            Console.ResetColor();
            Menu.VoltarMainMenu();
        }

        public static void Serializar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(sw, jogadores);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
                Console.ResetColor();
            }
            return jogadores;
        }
    }
}
