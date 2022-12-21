using JogoDaVelha.Controllers;
using JogoDaVelha.Entities;
using JogoDaVelha.Repository;
using JogoDaVelha.Services;

namespace JogoDaVelha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu.Abertura();

            Json data = new Json();

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
                        Json.Adicionar();
                        break;
                    case 2:
                        Json.Remover();
                        break;
                    case 3:
                        Ranking.MostrarRanking();
                        break;
                    case 4:
                        Jogador.DetalharJogador();
                        break;
                    case 5:
                        Json.Atualizar();
                        break;
                    case 6:
                        Jogar.Jogo();
                        break;
                }
            }
            while (option != 0);
        }
    }
}