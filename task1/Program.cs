/*

Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3

*/



/* 

Решил на этой задаче изучить регулярные выражения в C# :)
Человек вводит в консоль единой строкой ряд чисел, программа распознаёт числа по отдельности и оформляет в массив

*/

using System.Text.RegularExpressions;

// Получаем через консоль от пользователя данные в виде ряда чисел без требований к разделителям
// Потом через регулярку преобразовываем их в массив чисел
int[] GetNumsArrFromConsole()
{
    int[] numsArr = new int[0];
    string numsRow;
    int result;
    int i;

    while(true)
    {
        Console.Write("Введите ряд чисел: ");
        
        numsRow = Console.ReadLine() ?? "";

        // Ищем в введённой строке numsRow числа
        string pattern = @"-?\d+";
        Regex regex = new Regex(pattern);

        // Если числа найдены, собираем их в массив numsArr
        if (Regex.IsMatch(numsRow, pattern)) 
        {
            MatchCollection matches = regex.Matches(numsRow);
            
            i = 0;
            foreach (Match match in matches)
            {
                if (int.TryParse(match.Value, out result)) {
                    Array.Resize(ref numsArr, i + 1);
                    numsArr[i ++] = result;
                }
            }

            return numsArr;
        }
        
        // Числа в строке не найдены
        else {
            Console.WriteLine("Введены некорректные данные.");
            Array.Clear(numsArr);
        }
    }
}

// Выводит массив в консоль
void PrintArray(string message, int[] array)
{
    Console.Write(message+": ");

    Console.Write("[");
    for (int i = 0; i < array.Length; i ++)
        Console.Write(array[i]+(i < array.Length - 1 ? ", " : ""));
    Console.Write("]");

    Console.WriteLine();
}

// Подсчитывает кол-во чисел в массиве больше нуля
int GetPositiveNumbersCount(int[] numsArr) 
{
    int count = 0;

    for (int i = 0; i < numsArr.Length; i ++)
    {
        if (numsArr[i] > 0)
            count ++;
    }

    return count;
}



int[] numsArr = GetNumsArrFromConsole();

PrintArray("Полученные числа", numsArr);

Console.WriteLine("Чисел больше 0: "+GetPositiveNumbersCount(numsArr));