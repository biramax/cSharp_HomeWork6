/*

Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

*/


// Получает целое число от пользователя
int GetNumber(string message, bool notNull = false, bool notNegative = false)
{
    int number = 0;

    while (true)
    {
        Console.Write(message+": ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out number))
        {
            if (notNull && number == 0)
                Console.WriteLine("Число не должно быть равно нулю.");
            
            else if (notNegative && number < 0)
                Console.WriteLine("Число должно быть положительным.");
                        
            else
                return number;
        }
            
        else
            Console.WriteLine(input.Trim() == "" ? "Вы ничего не ввели." : "Вы ввели некорректные данные.");
    }
}



double b1 = GetNumber("Введите значение параметра b1");
double k1 = GetNumber("Введите значение параметра k1");
double b2 = GetNumber("Введите значение параметра b2");
double k2 = GetNumber("Введите значение параметра k2");

// Исключаем введение одинаковых значений параметров для обоих графиков
if (b1 == b2 && k1 == k2)
{
    Console.WriteLine("Прямые совпадают.");
    return;
}

// Чтобы найти точку пересечения графиков, нужно приравнять их функции:
// k1 * x + b1 = k2 * x + b2
// Находим x. Подставляем в функцию любого графика - получаем y
// Координата [x, y] будет точкой пересечения графиков

double x = (b2 - b1) / (k1 - k2);
double y = k1 * x + b1;
x = Math.Round(x, 2);
y = Math.Round(y, 2);

Console.WriteLine($"Точка пересечения графиков: [{x}, {y}]");