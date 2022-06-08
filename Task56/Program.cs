/*Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.*/

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
    Console.WriteLine("Заполненная матрица");
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");

        Console.WriteLine();
    }
}


void MatrixPrintSum(int[,] matrix, int[] laneArray, int laneIndex)
{
    Console.WriteLine($"В строке {laneIndex + 1} самая маленькая сумма ( {laneArray[laneIndex]} )");
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"Строка {i + 1}");
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"\t{matrix[i, j],3}");
        Console.Write($"\t Сумма строки: {laneArray[i]}");
        Console.Write("\n");
    }
}

(int[], int) MinSum(int[,] matrix)
{
    int[] laneSummary = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            laneSummary[i] += matrix[i, j];
    int min = laneSummary[0];
    int minLaneIndex = 0;
    for (int i = 0; i < laneSummary.Length; i++)
        if (laneSummary[i] < min)
        {
            min = laneSummary[i];
            minLaneIndex = i;
        }
    return (laneSummary, minLaneIndex);
}

int firstDemension = NumberInput("Введите кол-во строк:  ");
int secondDemension = NumberInput("Введите столбцов:  ");

int[,] resultMatrix = InitMatrix(firstDemension, secondDemension);


PrintMatrix(resultMatrix);
(int[] lanesSumMatrix, int minLaneSumIndex) = MinSum(resultMatrix);
Console.WriteLine();
Console.WriteLine("Итог: ");
Console.WriteLine();
MatrixPrintSum(resultMatrix, lanesSumMatrix, minLaneSumIndex);
