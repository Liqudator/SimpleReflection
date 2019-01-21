using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourcesReflection
{
    public class ListOfNumbers
    {
        /// <summary>
        /// Коллекция int чисел.
        /// </summary>
        public static List<int> intNumbers = new List<int>() { 1, -2, -5, 3, 4, 0, 7, -4 };

        /// <summary>
        /// Коллекция decimal чисел.
        /// </summary>
        public static List<decimal> decimalNumbers = new List<decimal> { 1, 3, 6, 78, 23, 23, 5, 8 };
    }
}
