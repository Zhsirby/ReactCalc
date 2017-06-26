using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, i'm Калькулятор");

            int x = 0;
            int y = 0;
            var calc = new Calc();

            if (args.Length == 2)
                {
                    x = ToInt(args[0], 70);
                    y = ToInt(args[1], 83);
                }
            else
                {
                    #region Ввод данных

                    Console.WriteLine("Введите Х");
                    var strx = Console.ReadLine();
                    x = ToInt(strx);

                    Console.WriteLine("Введите Y");
                    var stry = Console.ReadLine();
                    y = ToInt(stry, 99);

                    #endregion
                }

            var result = calc.Sum(x, y);

            Console.WriteLine("Сумма = " + result.ToString());

            Console.ReadKey();
        }

        /// <summary>
        /// Строку в инт
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="def">Если не удалось распарсить, то возвращаем это значение</param>
        /// <returns></returns>
        private static int ToInt(string arg, int def = 100)
        {
            int x;
            if (!int.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }
    }

}

