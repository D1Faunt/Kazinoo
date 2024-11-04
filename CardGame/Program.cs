using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program //Казино =)
    {
        static Dictionary<char, int> colorDict = new Dictionary<char, int>() 
        {
            {'R', 7},
            {'O', 6},
            {'Y', 5},
            {'G', 4},
            {'C', 3},
            {'B', 2},
            {'P', 1}
        };

        static (int, char) HighestCard(int[] values, char[] colors) //жёсткий поиск старшей карты по номеру и цвету
        {
            (int value, char color) bestcard = (values[0], colors[0]); //жёсткий кортеж

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > bestcard.value) //тута сравниваем числа
                {
                    bestcard = (values[i], colors[i]);
                }
                else if (values[i] == bestcard.value && colorDict[colors[i]] > colorDict[bestcard.color]) //тут если числа одинаковы, то сравниваем по теплоте
                {
                    bestcard = (values[i], colors[i]);
                }
            }
            return bestcard;
        }

        static int ComparisonCart((int, char) card1, (int, char) card2) //Не жёсткий метод для сравнения карт
        {
            if (card1.Item1 > card2.Item1) //сравниваем по числам
            {
                return 1; 
            }
            else if (card1.Item1 < card2.Item1)//и тут
            {
                return -1; 
            }
            else
            {
                return colorDict[card1.Item2] > colorDict[card2.Item2] ? 1 : -1; //а вот тут уже по цвету
            }
        }


        static void Main(string[] args)
        {
            Console.Write("Введите размер первой комбинации: ");

            int N1 = int.Parse(Console.ReadLine()); // после того как пользователь вводит например 5 R, разделяем 5 и R и храним их в массивах
            int[] A1 = new int[N1];
            char[] B1 = new char[N1];

            for (int i = 0; i < N1; i++)
            {
                Console.Write($"Введите число и цвет карты {i + 1} первой комбинации: ");// 1 A
                string[] input = Console.ReadLine().Split(' ');

                A1[i] = int.Parse (input[0]);
                B1[i] = char.Parse (input[1]);
            }

            Console.Write("Введите размер второй комбинации: ");

            int N2 = int.Parse(Console.ReadLine());
            int[] A2 = new int[N2];
            char[] B2 = new char[N2];

            for (int i = 0; i < N2; i++)
            {
                Console.Write($"Введите число и цвет карты {i + 1} второй комбинации: "); // 1 A
                string[] input = Console.ReadLine().Split(' ');

                A2[i] = int.Parse (input[0]);
                B2[i] = char.Parse (input[1]);
            }

            (int, char) highestCard1 = HighestCard(A1, B1); //тута вычисляем по ip старшие карты
            (int, char) highestCard2 = HighestCard(A2, B2);

            int result = ComparisonCart(highestCard1 , highestCard2);

            if (result > 0) //пожилой вывод
            {
                Console.WriteLine("Выйграла первая комбинация");
                Console.WriteLine($"Старшая карта: {highestCard1.Item1} {highestCard1.Item2}");
            }
            else
            {
                Console.WriteLine("Выйграла вторая комбинация");
                Console.WriteLine($"Старшая карта: {highestCard2.Item1} {highestCard2.Item2}");
            }
            Console.ReadLine();
        }
    }
}
