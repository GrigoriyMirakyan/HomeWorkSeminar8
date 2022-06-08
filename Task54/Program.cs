/*Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.*/

Console.Clear();

int NumberInput(string text)//Метод ввода и проверки на число
{
    bool isInputInt = true;
    int number = 0;
    while (isInputInt)
    {
        Console.Write(text);
        string numberSTR = Console.ReadLine();
        if (int.TryParse(numberSTR, out int numberInt))
        {
            if (numberInt <= 0) Console.WriteLine("Введите число больше нуля");
            else
            {
                number = numberInt;
                isInputInt = false;
            }
        }
        else
            Console.WriteLine("Ввели не число");
    }
    return number;
}

int[,] InitMatrix(int firstDemension, int secondDemension)   // Создание и наполнение матрицы
{
    int[,] matrix = new int[firstDemension, secondDemension];
    Random rnd = new Random();
    for (int i = 0; i < firstDemension; i++)
    {
        for (int j = 0; j < secondDemension; j++)
            matrix[i, j] = rnd.Next(1, 20);
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)    // Вывод матрицы в консоль
{
    Console.WriteLine();
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");

        Console.WriteLine();
    }
}

void SortMatrix(int[,] matrix) // по ощущение - тут могла бы быть рекурсия, но что-то как-то не заходит =)
{
    int max;
    int maxRow;
    int maxColum;
    for (int n = 0; n < matrix.GetLength(0); n++)
    {
        for (int m = 0; m < matrix.GetLength(1); m++)
        {
            max = matrix[n, m];
            maxRow = n;
            maxColum = m;
            for (int i = m; i < matrix.GetLength(1); i++)
            {
                if (max <= matrix[n, i])
                {
                    max = matrix[n, i];
                    maxRow = n;
                    maxColum = i;
                }
            }
            matrix[maxRow, maxColum] = matrix[n, m];
            matrix[n, m] = max;
        }
    }
}

int firstDemension = NumberInput("Введите кол-во строк:  ");
int secondDemension = NumberInput("Введите столбцов:  ");

int[,] resultMatrix = InitMatrix(firstDemension, secondDemension);

Console.WriteLine();
Console.WriteLine("Изначальная матрица: ");
PrintMatrix(resultMatrix);
SortMatrix(resultMatrix);
Console.WriteLine();
Console.WriteLine("Отсортированная матрица: ");
PrintMatrix(resultMatrix);

