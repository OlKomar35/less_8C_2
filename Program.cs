//Задача 56: Задайте прямоугольный двумерный массив.
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.

//Например, задан массив:

//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7
//Программа считает сумму элементов в каждой строке и выдаёт номер строки 
//с наименьшей суммой элементов: 1 строка


int[,] CreateArray(int m, int n, int start, int finish)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Random random = new Random();
            array[i, j] = random.Next(start, finish + 1);
        }
    }
    return array;
}


void PrintArray(int[,] array)
{
    Console.Write("[");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if ((i != array.GetLength(0) - 1) || (j != array.GetLength(1) - 1))
                Console.Write($"{array[i, j]}; ");
            else
                Console.WriteLine($"{array[i, j]}]");
        }
        Console.WriteLine();
    }
}

int[] RowArray(int[,] arr, int row)
{
    int[] rowArr = new int[arr.GetLength(1)];
    for (int col = 0; col < arr.GetLength(1); col++)
    {
        rowArr[col] = arr[row, col];
    }
    return rowArr;
}

int SumElements(int[] rowArray)
{
    int sumElem = 0;
    foreach (var item in rowArray)
    {
        sumElem += item;
    } 
    return sumElem;
}


Console.Write("Введите количество строк массива m= ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива n= ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите начало диапозона start= ");
int start = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите окончание диапазона finish= ");
int finish = Convert.ToInt32(Console.ReadLine());
if (finish < start)
{
    int temp = finish;
    finish = start;
    start = temp;
}


int[,] arr = CreateArray(m, n, start, finish);
PrintArray(arr);
int[] rowArr0 = RowArray(arr, 0);
int minSum = SumElements(rowArr0);
int minRow =0;
for (int row = 1; row < arr.GetLength(0); row++)
{
    int[] rowArr = RowArray(arr, row);
    int sumElem = SumElements(rowArr);
    if (sumElem < minSum)
    {
        minSum = sumElem;
        minRow = row;
    }
}
Console.WriteLine($"строка {minRow+1} с минимальной суммой элементов");