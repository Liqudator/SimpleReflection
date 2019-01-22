using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======= Late Binding ========");
            // попробовать загрузить локальную копию ListOfNumber
            Assembly asm = null;
            try
            {
                // загрузка сборки SourcesReflection.dll
                asm = Assembly.Load("SourcesReflection");
            }
            catch (FileNotFoundException e) // не нашли указанную сборку
            {
                Console.WriteLine(e.Message);
                return;
            }
            // если asm указывает на загруженную сборки
            if (asm != null)
                // запускаем метод для работы с объектами сборки 
                CreateUsingLateBinding(asm);
            Console.ReadLine();
        }

        /// <summary>
        /// Метод, реализующий вывод доступных методов указанного объекта, загруженной сборки и
        /// вызывающий его методы
        /// </summary>
        /// <param name="asm">Ссылка на загружаемую сборку</param>
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // получить метаданные для типа Methods
                Type methods = asm.GetType("SourcesReflection.OperationsWithNumbers");
                
                // создать объект methods на лету
                var obj = Activator.CreateInstance(methods);
                Console.WriteLine($"Created object {obj}");

                // получение всех методов сборки
                MethodInfo[] mii = methods.GetMethods();
                foreach (var i in mii)
                {
                    Console.WriteLine($"->{i.Name}");
                }

                // попытка использования public метода Add
                MethodInfo mi1 = methods.GetMethod("Sum");
                // вызов метода Add
                mi1.Invoke(obj, null);
                // попытка использования private метода Average
                MethodInfo mi2 = methods.GetMethod("Average");
                // вызов метода Average
                // UPD: в консоли пишет ссылка на объект не указывает на экземпляр объекта
                // так как модификатор доступа private
                mi2.Invoke(obj, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
