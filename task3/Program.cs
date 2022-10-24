/* Найдите максимальное значение в матрице по каждой строке,
 получите сумму этих максимумов. Затем найдите минимальное значение
 по каждой колонке,получите сумму этих минимумов. Затем из первой
*/ 


// Заполнение массива случайными числами.
int[,] CreateMatrix(int i, int j)
{
    int[,] matr = new int[i,j];
    for(i = 0; i < matr.GetLength(0); i++)
    {
        for(j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1,10);
        }
    }
    return matr;
}
// Метод вывода матрицы.
void PrintMatrix(int[,] matr)
{
    for(int i = 0; i < matr.GetLength(0); i++)
    {
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} ");
        }
        Console.WriteLine();
    }
}
// Метод вывода массива.
void PrintArray(int[] col)
{
    int count = col.Length;
    for (int position = 0; position < count; position++)
        Console.Write($"{col[position]}\t");
    Console.WriteLine();
}

int[] MaxInRows(int[,] matr)
{
    int[] maxNumbers = new int[matr.GetLength(0)];
    int max = 0;
    // Ищем максимумы в каждой строчке и записываем в массив.
    for(int i = 0; i < matr.GetLength(0); i++)
    {
        max = matr[i,0]; // Ставим максимум на первый элемент строки.
        for(int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i,j] > max) max = matr[i,j];
        }
        maxNumbers[i] = max; // Записываем максимум в массивю
    }
    return maxNumbers;
}

int[] MinInColumns(int[,] matr)
{
    int[] minNumbers = new int[matr.GetLength(1)];
    int min = 0;
    // Ищем минимумы в каждом столбце и записываем в массив.
    for(int j = 0; j < matr.GetLength(1); j++)
    {
        min = matr[0,j]; // Ставим минимум на первый элемент столбца.
        for(int i = 0; i < matr.GetLength(0); i++)
        {
            if (matr[i,j] < min) min = matr[i,j];
        }
        minNumbers[j] = min; // Записываем минимум в массив.
    }
    return minNumbers;
}
// Метод, который суммирует все элементы в массиве.
int SumArray (int[] array)
{
    int sum = 0;
    for(int index = 0; index < array.Length; index++) sum += array[index];
    return sum;
}

int[,] matrix = CreateMatrix(5, 5);
Console.WriteLine("Наша матрица:");
PrintMatrix(matrix);
Console.WriteLine("Максимальные значения из каждой строки:");
PrintArray(MaxInRows(matrix));
Console.WriteLine("Минимальные значения из каждого столбца:");
PrintArray(MinInColumns(matrix));

int maxSum = SumArray(MaxInRows(matrix));
int minSum = SumArray(MinInColumns(matrix));
Console.WriteLine("Сумма максимальных значений строк минус сумма минимальных значений столбцов:");
Console.WriteLine($"{maxSum} - {minSum} = {maxSum - minSum}");