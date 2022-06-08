//Задача 62: Заполните спирально массив 4 на 4.


internal class Program
{
    private static void Main(string[] args)
    {
        void InitMatrix(int[,] matrix, int i, int j)
        {

            while (i > -1 && i < 4 && j > -1 && j < 4)
            {
                if (matrix[i, j] == 0)
                {
                    Random rnd = new Random();
                    matrix[i, j] = rnd.Next(10, 100);
                    InitMatrix(matrix, i - 1, j);
                    InitMatrix(matrix, i, j - 1);
                    InitMatrix(matrix, i + 1, j);
                    InitMatrix(matrix, i, j + 1);
                }
                else
                {
                    break;
                }

            }

        }

        void PrintMatrix(int[,] matrix)
        {
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }
        }

        int i = 3;
        int j = 3;
        int firstDemension = 4;
        int secondDemension = 4;
        int[,] matrix = new int[firstDemension, secondDemension];

        InitMatrix(matrix, i, j);
        PrintMatrix(matrix);
    }
}
