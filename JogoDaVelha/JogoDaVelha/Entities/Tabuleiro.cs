namespace JogoDaVelha.Entities
{
    public class Tabuleiro
    {
        public static string[,] GerarTabuleiro(int tamanho)
        {
            string[,] matriz = new string[tamanho,tamanho];
            int posicao = 1;
            for (int i=0; i<tamanho; i++)
            {
                for (int j=0; j<tamanho; j++)
                {
                    matriz[i, j] = posicao.ToString();
                    posicao++;
                }
            }
            return matriz;
        }
        public static void MostrarTabuleiro(string[,] tabuleiro, int tamanho)
        {
            Console.Clear();
            Console.WriteLine("\n");
            for (int i = 0; i < tamanho; i++)
            {
                Console.Write("\t ");
                for (int j = 0; j < tamanho; j++)
                {
                    Console.Write($"[{tabuleiro[i,j]}] ");
                }
                Console.WriteLine();
            }
        }
        public static void AlterarTabuleiro(string posicao, int tamanho, string[,] tabuleiro, string valor)
        {
            
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiro[i,j]==posicao)
                    {
                        tabuleiro[i, j] = valor;
                    }
                }
            }
        }
        public static bool VerificarTabuleiro(string posicao, int tamanho, string[,] tabuleiro, string valor)
        {
            int somaDiagPrin = 0;
            int somaDiagSec = 0;
            for (int i = 0; i < tamanho; i++)
            {
                int somaLinha = 0;
                int somaColuna = 0;
                for (int j = 0; j < tamanho; j++)
                {
                    if (tabuleiro[i, j] == valor) somaLinha++;
                    if (tabuleiro[j, i] == valor) somaColuna++;
                    if (i == j && tabuleiro[i,i] == valor) somaDiagPrin++;
                    if (i + j == tamanho - 1 && tabuleiro[i, j] == valor) somaDiagSec++;
                }
                if (somaLinha == tamanho) return true;
                if (somaColuna == tamanho) return true;
            }
            if (somaDiagPrin == tamanho) return true;
            if (somaDiagSec == tamanho) return true;
            return false;
        }
    }
}
