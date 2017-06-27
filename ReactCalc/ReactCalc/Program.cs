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
            Console.WriteLine("Вы можете два числа: складывать, вычитать, умножать, делить.\nИ найти корень суммы x, y.");

            double x = 0;
            double y = 0;
            var calc = new Calc();
            string arithmeticOperation = "00";
            double result = 0;

            if (args.Length == 2)
                {
                    x = ToInt(args[0], 10);
                    y = ToInt(args[1], 10);
                }
            else
                {
                    #region Ввод данных

                    Console.WriteLine("Введите Х");
                    var strx = Console.ReadLine();
                    x = ToInt(strx, 100);

                    Console.WriteLine("Введите Y");
                    var stry = Console.ReadLine();
                    y = ToInt(stry, 99);

                    #endregion
                }
            Console.WriteLine("Выберите действие '+' '-' '*' '/' 'Sqrt'");
            arithmeticOperation = Console.ReadLine();
            if (arithmeticOperation == "+")
            {
                result = calc.Sum(x, y);
                Console.WriteLine("Сумма = " + result.ToString());
            }
            else if (arithmeticOperation == "-")
            {
                result = calc.Subtract(x, y);
                Console.WriteLine("Разница = " + result.ToString());
            }
            else if (arithmeticOperation == "*")
            {
                result = calc.Multiplication(x, y);
                Console.WriteLine("Произведение = " + result.ToString());
            }
            else if (arithmeticOperation == "/")
            {
                result = calc.Divide(x, y);
                Console.WriteLine("Частное = " + result.ToString());
            }
            else if (arithmeticOperation == "Sqrt")
            {
                result = calc.SqrtNumber(x, y);
                Console.WriteLine("Корень X + Y = " + result.ToString());
            }




                Console.ReadKey();
        }

        /// <summary>
        /// Строку в инт
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="def">Если не удалось распарсить, то возвращаем это значение</param>
        /// <returns></returns>
        private static double ToInt(string arg, double def)
        {
            double x;
            if (!double.TryParse(arg, out x))
            {
                x = def;
            }

            return x;
        }
    }

}

