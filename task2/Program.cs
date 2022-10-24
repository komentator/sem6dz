/*Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)


*/ 
const int K = 0;
const int B = 1;
const int X = 0;
const int Y = 1;

int Prompt(string message) // Метод ввода с консоли.
{
    Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

double[] InputLines(int point) // Ввод с консоли углового коэффициента и числа для уравнения прямой (Y = K*X + B).
{
    double[] options = new double[2];
    options[K] = Prompt($"Введите угловой коэффициент K{point}: ");
    options[B] = Prompt($"Введите число B{point}: ");
    Console.WriteLine();
    return options;
}

// Проверка на наличие пересечения у прямых с заданными параметрами.
bool ValidateIntersection (double[] line1, double[] line2)
{
    if (line1[K] == line2[K] && line1[B] == line2[B])
    {
        Console.WriteLine("Прямые совпадают!");
        return false;
    }
    if (line1[K] == line2[K])
    {
        Console.WriteLine("Прямые паралельны!");
        return false;
    }
    return true;
}

// Вычисление координат точки пересечения двух прямых путем вывода X
// из сиситемы уравнений Y = K1*X + B1, Y = K2*X + B2, то есть
// K1*X + B1 = K2*X + B2, тогда X = (B2 - B1)/(K1 - K2)
double[] IntersectionCoords (double[] line1, double[] line2)
{
    double[] coords = new double[2];
    coords[X] = (line2[B] - line1[B])/(line1[K] - line2[K]);
    coords[Y] = line1[K]*coords[X] + line1[B]; // Чтобы узнать Y, надо подставить значение X в одну из заданных функций.
    return coords;
}

double[] firstLine = InputLines(1);
double[] secondLine = InputLines(2);

if (ValidateIntersection(firstLine, secondLine))
{
    double[] intersection = IntersectionCoords(firstLine, secondLine);
    Console.WriteLine($"Точка пересечения прямых имеет координаты: ({intersection[X]:f1};{intersection[Y]:f1})");
}