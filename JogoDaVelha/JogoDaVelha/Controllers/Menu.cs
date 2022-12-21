using JogoDaVelha.Repository;

namespace JogoDaVelha.Controllers
{
    public class Menu
    {
        public static void Abertura()
        {
            Console.WriteLine("\n\tBem-vindo(a) ao Jogo da Velha.");
            Console.Write("\n\tPressione qualquer tecla para acessar ao menu ");
            Console.ReadKey();
        }
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tEscolha uma opção para continuar: ");
            Console.WriteLine("\n\t1 - Cadastrar novo Jogador");
            Console.WriteLine("\t2 - Deletar Jogador");
            Console.WriteLine("\t3 - Ranking de Jogadores");
            Console.WriteLine("\t4 - Detalhes de um Jogador");
            Console.WriteLine("\t5 - Mudar nickname de Jogador");
            Console.WriteLine("\t6 - Jogar");
            Console.WriteLine("\t0 - Sair do jogo");
            Console.Write("\n\tDigite a opção desejada: ");
        }
        public static void VoltarMainMenu()
        {
            Console.Write("\n\tPressione qualquer tecla para voltar ao menu ");
            Console.ReadKey();
        }
        public static string GetNickname()
        {
            Console.Write("\n\tDigite o Nickname: ");
            string name = Console.ReadLine();
            return name;
        }
        public static string ExisteJogador(string nickname)
        {
            while (Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.WriteLine("\n\tJogador já cadastrado. Tente novamente.");
                nickname = GetNickname();
            }
            return nickname;
        }
        public static string NaoExisteJogador(string nickname)
        {
            while (!Json.jogadores.Any(player => player.Nickname == nickname))
            {
                Console.WriteLine("\n\tJogador não cadastrado. Tente novamente.");
                nickname = GetNickname();
            }
            return nickname;
        }
        public static void Encerrar()
        {
            Console.Clear();
            Console.WriteLine("\n\tEncerrando o Jogo da Velha.\n\n\tObrigado por jogar.\n");
        }
    }
}