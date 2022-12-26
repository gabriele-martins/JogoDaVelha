using JogoDaVelha.Repository;

namespace JogoDaVelha.Controllers
{
    public class Menu
    {
        public static void Abertura()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\r\n\t     ██  ██████   ██████   ██████      ██████   █████      ██    ██ ███████ ██      ██   ██  █████  \r\n\t     ██ ██    ██ ██       ██    ██     ██   ██ ██   ██     ██    ██ ██      ██      ██   ██ ██   ██ \r\n\t     ██ ██    ██ ██   ███ ██    ██     ██   ██ ███████     ██    ██ █████   ██      ███████ ███████ \r\n\t██   ██ ██    ██ ██    ██ ██    ██     ██   ██ ██   ██      ██  ██  ██      ██      ██   ██ ██   ██ \r\n\t █████   ██████   ██████   ██████      ██████  ██   ██       ████   ███████ ███████ ██   ██ ██   ██ \r\n\t                                                                                                    ");
            Console.WriteLine("\n\tBem-vindo(a) ao Jogo da Velha.");
            Console.Write("\n\tPressione qualquer tecla para acessar ao menu ");
            Console.ReadKey();
            Console.ResetColor();
        }
        public static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.WriteLine("\n\tEscolha uma opção para continuar: ");
            Console.ResetColor();
            Console.Write("\n\t1 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Cadastrar novo Jogador");
            Console.ResetColor();
            Console.Write("\t2 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Deletar Jogador");
            Console.ResetColor();
            Console.Write("\t3 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Ranking de Jogadores");
            Console.ResetColor();
            Console.Write("\t4 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Detalhes de um Jogador");
            Console.ResetColor();
            Console.Write("\t5 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Mudar nickname de Jogador");
            Console.ResetColor();
            Console.Write("\t6 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Jogar");
            Console.ResetColor();
            Console.Write("\t0 ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("- Sair do jogo");
            Console.Write("\n\tDigite a opção desejada: ");
            Console.ResetColor();
        }
        public static void VoltarMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tPressione qualquer tecla para voltar ao menu ");
            Console.ReadKey();
            Console.ResetColor();
        }
        public static string GetNickname()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\tDigite o Nickname: ");
            Console.ResetColor();
            string name = Console.ReadLine();
            return name;
        }
        public static string ExisteJogador(string nickname)
        {
            while (Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador já cadastrado. Tente novamente.");
                Console.ResetColor();
                nickname = GetNickname();
            }
            return nickname;
        }
        public static string NaoExisteJogador(string nickname)
        {
            while (!Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                Console.ResetColor();
                nickname = GetNickname();
            }
            return nickname;
        }
        public static void Encerrar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\tEncerrando o Jogo da Velha.\n\n\tObrigado por jogar.\n");
        }
    }
}