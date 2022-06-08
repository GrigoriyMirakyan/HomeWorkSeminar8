/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.*/

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
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} ");

        Console.WriteLine();
    }
}

int[,] multiplyMatrix(int[,] matrixA, int[,] matrixB)
{
    int rowsMatrixA = matrixA.GetLength(0);
    int columsMatrixA = matrixA.GetLength(1);
    int columsMatrixB = matrixB.GetLength(1);
    int[,] multiplyMatrix = new int[rowsMatrixA, columsMatrixB];
    for (int i = 0; i < rowsMatrixA; i++)
        for (int j = 0; j < columsMatrixB; j++)
            for (int n = 0; n < columsMatrixA; n++)
                multiplyMatrix[i, j] += matrixA[i, n] * matrixB[n, j];
    return multiplyMatrix;
}

int secondDemensionA = NumberInput("Введите кол-во стобцов / строк первой матрицы:  ");
int firstDemensionA = secondDemensionA;
int secondDemensionB = NumberInput("Введите кол-во стобцов / строк второй матрицы:  ");
int firstDemensionB = secondDemensionB;


int[,] matrixA = InitMatrix(firstDemensionA, secondDemensionA);
Console.Write("\nМатрица А: \n");
PrintMatrix(matrixA);

int[,] matrixB = InitMatrix(firstDemensionB, secondDemensionB);
Console.Write("\nМатрица B: \n");
PrintMatrix(matrixB);

int[,] multiplMatrix = multiplyMatrix(matrixA, matrixB);
Console.Write("\nМатрица произведения: \n");
PrintMatrix(multiplMatrix);
