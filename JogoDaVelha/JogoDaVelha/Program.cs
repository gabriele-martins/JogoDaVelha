using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using JogoDaVelha.Repository;

namespace JogoDaVelha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu.Abertura();

            JSON data = new JSON();

            int option=10;
            do
            {
                Menu.ShowMainMenu();

                try
                {
                    option=int.Parse(Console.ReadLine());
                    if (option<0 || option>6)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\tOpção inserida inválida. Tente novamente.");
                        Menu.VoltarMainMenu();
                    }
                }
                catch 
                {
                    Console.Clear();
                    Console.WriteLine("\n\tLetras ou caractéres não são válidos. Tente novamente.");
                    Menu.VoltarMainMenu();
                }

                switch (option)
                {
                    case 0:
                        Menu.Encerrar();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\tCadastrar novo Jogador.");
                        string nickname = Menu.GetNickname();
                        Jogador novoJogador = new Jogador(nickname);
                        JSON.SerializarAdd(novoJogador);
                        Menu.VoltarMainMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n\tDeletar Jogador.");
                        nickname = Menu.GetNickname();
                        JSON.SerializarRemove(nickname);
                        Menu.VoltarMainMenu();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }
            }
            while (option != 0);
        }
    }
}