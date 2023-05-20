using System;

namespace LW18_1
{
    class Program
    {
        static void Main(string[] args)
        {
            static double CalculateProductOfElementsWithEvenIndexes(double[] array)
            {
                double product = 1;
                for (int i = 0; i < array.Length; i += 2)
                {
                    product *= array[i];
                }
                return product;
            }

            static double CalculateSumOfElementsBetweenZeros(double[] array)
            {
                int firstZeroIndex = -1;
                int lastZeroIndex = -1;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                    {
                        if (firstZeroIndex == -1)
                        {
                            firstZeroIndex = i;
                        }
                        lastZeroIndex = i;
                    }
                }

                if (firstZeroIndex == -1 || lastZeroIndex == -1)
                {
                    return 0; // Якщо немає нульових елементів, повертаємо 0
                }

                double sum = 0;
                for (int i = firstZeroIndex + 1; i < lastZeroIndex; i++)
                {
                    sum += array[i];
                }
                return sum;
            }

            static void TransformArray(double[] array)
            {
                Array.Sort(array, (x, y) =>
                {
                    // Нульові елементи вважаються додатними і йдуть на початок
                    if (x == 0)
                    {
                        return -1;
                    }
                    else if (y == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -x.CompareTo(y);
                    }
                });
            }

            Console.Write("Введіть розмірність масиву: ");
            int n = int.Parse(Console.ReadLine());

            double[] array = new double[n];

            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть елемент масиву [{i}]: ");
                array[i] = double.Parse(Console.ReadLine());
            }

            double product = CalculateProductOfElementsWithEvenIndexes(array);
            Console.WriteLine("Добуток елементів масиву з парними номерами: " + product);

            double sum = CalculateSumOfElementsBetweenZeros(array);
            Console.WriteLine("Сума елементів масиву між першим і останнім нульовими елементами: " + sum);

            TransformArray(array);

            Console.WriteLine("Масив після перетворення:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}