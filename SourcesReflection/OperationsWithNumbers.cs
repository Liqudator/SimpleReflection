using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcesReflection
{
    /// <summary>
    /// Базовые оперции над числами
    /// </summary>
    public class OperationsWithNumbers
    {
        /// <summary>
        /// Вычисление суммы чисел коллекции
        /// </summary>
        public static void Sum()
        {
            Console.WriteLine($"Сумма int чисел = {ListOfNumbers.intNumbers.Sum()}");
            Console.WriteLine($"Сумма decimal чисел = {ListOfNumbers.decimalNumbers.Sum()}");
        }

        /// <summary>
        /// Вычисление среднего арифметического чисел коллекции
        /// </summary>
        private static void Average()
        {
            Console.WriteLine($"Среднее арифметическое int чисел = {ListOfNumbers.intNumbers.Average()}");
            Console.WriteLine($"Среднее арифметическое decimal чисел = {ListOfNumbers.decimalNumbers.Average()}");
        }
    }
}
