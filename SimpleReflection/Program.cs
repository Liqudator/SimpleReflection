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
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            if (asm != null)
                CreateUsingLateBinding(asm);
            Console.ReadLine();
        }

        /// <summary>
        /// Вывод всех методов сборки, 
        /// </summary>
        /// <param name="asm">Ссылка на загружаемую сборку</param>
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // получить метаданные для типа Methods
                Type methods = asm.GetType("ListOfNumber.Methods");
                
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
                MethodInfo mi1 = methods.GetMethod("Add");
                // попытка использования private метода Sub
                MethodInfo mi2 = methods.GetMethod("Average");
                // вызов метода Add
                mi1.Invoke(obj, null);
                // вызов метода Average
                mi2.Invoke(obj, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
