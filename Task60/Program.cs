/*Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.*/

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

int[,,] InitMatrix(int firstDemension, int secondDemension, int thirdDemension)   // Создание и наполнение матрицы
{
    int[,,] matrix = new int[firstDemension, secondDemension, thirdDemension];
    Random rnd = new Random();
    for (int i = 0; i < firstDemension; i++)
    {
        for (int j = 0; j < secondDemension; j++)
        {
            for (int k = 0; k < thirdDemension; k++)
            {
                bool uniqueNumber = true;
                while (uniqueNumber)
                {
                    matrix[i, j, k] = rnd.Next(10, 100);
                    uniqueNumber = SearchNumberInMatrix(matrix[i, j, k], matrix);
                }
            }
        }
    }

    return matrix;
}

void PrintMatrixLine(int[,,] matrix)
{
    Console.Write($"\nx.j.k.\tNum\n");
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
                Console.Write($"{i}.{j}.{k}.\t{matrix[i, j, k]}\n");
}

bool SearchNumberInMatrix(int number, int[,,] matrix)//Метод проверки есть ли такое число в массиве
{
    bool result = true;
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            for (int k = 0; k < matrix.GetLength(2); k++)
                if (number == matrix[i, j, k]) result = false;
    return result;
}

int firstDemension = NumberInput("Введите кол-во строк:  ");
int secondDemension = NumberInput("Введите кол-во столбцов:  ");
int thirdDemension = NumberInput("Введите глубину матрицы:  ");

if (firstDemension * secondDemension * thirdDemension > 99)
    Console.WriteLine("Количество цифр в массиве не позволяет использовать уникальные двухзначные числа");
else
{
    int[,,] superMatrix = InitMatrix(firstDemension, secondDemension, thirdDemension);
    PrintMatrixLine(superMatrix);
}