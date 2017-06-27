using FactorialLibrary;
using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ReactCalc
{
    public class Calc
    {
        public Calc()
        {
            Operations = new List<IOperation>();
            Operations.Add(new SumOperation());

            var dllName = "FactorialLibrary.dll";
            var fullPath = Directory.GetCurrentDirectory() + dllName;


            if (!Directory.Exists(fullPath))
            {
                return;
            }

            // Загружеаем сборку
            var assembly = Assembly.LoadFrom(dllName);
            // Получаем все типы классы из неё
            var types = assembly.GetTypes();
            // Перебираем типы
            foreach (var t in types)
            {
                // Находим тех, кто реализует  интерфейс IOperation
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation)))
                {
                    // Создаём экземпляр на денного класса
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        // Добавляем в список операций 
                        Operations.Add(instance);
                    }
                }
            }

            Operations.Add(new FactorialOperation());
        }

        public IList<IOperation> Operations { get; private set; }

        public double Execute(string name, double[] args)
        {
            // находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(i => i.Name == name);

            if (oper != null)
            {
                // вычисляем результат 
                var result = oper.Execute(args);
                // отдаём пользователю
                return result;
            }
            throw new Exception("Не найдена запрашиваемая операция");
        }
        public double Execute(long code, double[] args)
        {
            // находим операцию по имени
            IOperation oper = Operations.FirstOrDefault(i => i.Code == code);

            if (oper != null)
            {
                // вычисляем результат 
                var result = oper.Execute(args);
                // отдаём пользователю
                return result;
            }
            throw new Exception("Не найдена запрашиваемая операция");
        }
        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }

        /// <summary>
        /// Сумма двух чисел с плавающей точкой 
        /// </summary> 
        /// <param name="x">Первое слагаемое</param>
        /// <param name="y">Второе слагаемое</param>
        /// <returns>Сумма</returns>
        [Obsolete("Используйте Execute(SUM, new[] {x,y }). Данная функция будет удалена в версии 4.0")]
        public double Sum(double x, double y)
        {
            return Execute("sum", new[] { x, y });
        }

        /// <summary>
        /// Разность двух чисел с плавающей точкой 
        /// </summary>
        /// <param name="x">Слагаемое</param>
        /// <param name="y">Вычитаемое</param>
        /// <returns>Разность</returns>
        public double Subtract(double x, double y)
        {
            var sub = x - y;
            //Console.WriteLine("{0} - {1} = {2}", x, y, sub);
            return sub;
        }

        public double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }

        /// <summary>
        /// Произведение двух чисел с плавающей точкой 
        /// </summary>
        /// <param name="x">Первый множитель</param>
        /// <param name="y">Второй множитель</param>
        /// <returns>Произведение</returns>
        public double Multiply(double x, double y)
        {
            var mult = x * y;
            //Console.WriteLine("{0} * {1} = {2}", x, y, mult);
            return mult;
        }

        /// <summary>
        /// Частное двух чисел с плавающей точкой 
        /// </summary>
        /// <param name="x">Числитель</param>
        /// <param name="y">Знаменатель</param>
        /// <returns>Частное</returns>
        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Деление на нуль. Функция Divide не может принять нуль в качестве второго аргумента.");
            }
            var div = x / y;
            //Console.WriteLine("{0} / {1} = {2}", x, y, div);
            return div;
        }

        /// <summary>
        /// Квадратный корень числа
        /// </summary>
        /// <param name="x">Подкоренное число</param>
        /// <returns>Квадратный корень</returns>
        public double Sqrt(double x)
        {
            if (x < 0)
            {
                throw new ArithmeticException("Подкоренное выражение не может быть отрицательным.");
            }
            var sqrt = Math.Sqrt(x);
            //Console.WriteLine("Sqrt({0}) = {1}", x sqrt);
            return sqrt;
        }
    }
}