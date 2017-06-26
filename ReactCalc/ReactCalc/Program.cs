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
            Console.WriteLine("Hello, I m Калькулятор");

            Console.WriteLine("Введите x");
            var strx = Console.ReadLine();

            int x = 0;
            if (!int.TryParse(strx, out x))
            {
                x = 100;
            }

            Console.WriteLine("Введите y");
            var stry = Console.ReadLine();
            
            int y = 0;
            if (!int.TryParse(strx, out x))
            {
                y = 99;
            }

            var result = 0;

            Console.WriteLine("Сумма " + result.ToString());
            Console.ReadKey();
            
        }

    }
}
