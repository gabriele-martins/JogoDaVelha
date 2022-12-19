namespace JogoDaVelha
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\tBem-vindo(a) ao Jogo da Velha.");
            Console.Write("\n\tPressione qualquer tecla para acessar ao menu ");
            Console.ReadKey();

            int option=10;
            do
            {
                ShowMenu();
                try
                {
                    option=int.Parse(Console.ReadLine());
                    if (option<0 || option>6)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\tOpção inserida inválida. Tente novamente.");
                        Console.Write("\n\tPressione qualquer tecla para voltar ao menu ");
                        Console.ReadKey();
                    }
                }
                catch 
                {
                    Console.Clear();
                    Console.WriteLine("\n\tLetras ou caractéres não são válidos. Tente novamente.");
                    Console.Write("\n\tPressione qualquer tecla para voltar ao menu ");
                    Console.ReadKey();
                }

                switch (option)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\tEncerrando o Jogo da Velha.\n\n\tObrigado por jogar.");
                        Console.WriteLine("\n");
                        break;
                    case 1:
                        break;
                    case 2:
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
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tEscolha uma opção para continuar: ");
            Console.WriteLine("\n\t1 - Cadastrar novo Jogador");
            Console.WriteLine("\t2 - Deletar Jogador");
            Console.WriteLine("\t3 - Ranking de Jogadores");
            Console.WriteLine("\t4 - Detalhes de um Jogador");
            Console.WriteLine("\t5 - Maior quantidade de pontos");
            Console.WriteLine("\t6 - Jogar");
            Console.WriteLine("\t0 - Sair do jogo");
            Console.Write("\n\tDigite a opção desejada: ");
        }
    }
}