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
            double firstNum = 0.0001;
            double secondNum = 10000;
            int operationNumber = 1;
            Calc calc = new Calc();
            Console.WriteLine("\t\tHello, I'm ReactCalc.");
            Console.WriteLine("\tМатематические операции над числами\n");

            if (args.Length == 0)
            {
                #region Текстовое меню и выбор пункта 
                Console.WriteLine("Для начала выберем тип операции с числами");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Квадратный корень");
                Console.WriteLine("Введите номер интересующей операции");

                string userInput;
                while (true)
                {
                    userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out operationNumber))
                    {
                        if (operationNumber > 5)
                        {
                            operationNumber = 5;
                        }
                        else if (operationNumber < 1)
                        {
                            operationNumber = 1;
                        }
                        break;
                    }
                    Console.WriteLine("Не удаётся. Необходимо ввести числовое значение - номер интересующего пункта меню.");
                }
                #endregion

                #region Получение чисел
                Console.WriteLine("\tВведите первое число");
                firstNum = UserInputDouble();

                if (operationNumber != 5) // 5 - квадратный корень
                {
                    Console.WriteLine("\tВведите второе число");
                    secondNum = UserInputDouble();
                }
                #endregion
            }
            else
            {
                #region Получение чисел
                // попытаемся достать данные из командной строки по шаблону   [операция] [число] [число]
                int.TryParse(args[0], out operationNumber);
                double.TryParse(args[1], out firstNum);
                if (args.Length == 3)
                {
                    double.TryParse(args[2], out secondNum);
                }
                #endregion
            }

            #region Получение результата
            double result = GetResult(firstNum, secondNum, calc, operationNumber);
            #endregion

            #region Вывод на консоль
            Console.WriteLine("Результат:\t{0}", result);
            #endregion

        }

        private static double GetResult(double firstNum, double secondNum, Calc calc, int operationNumber)
        {
            double result;
            switch (operationNumber)
            {
                case (1):
                    result = calc.Sum(firstNum, secondNum);
                    Console.WriteLine("{0} + {1}", firstNum, secondNum);
                    break;
                case (2):
                    result = calc.Subtract(firstNum, secondNum);
                    Console.WriteLine("{0} - {1}", firstNum, secondNum);
                    break;
                case (3):
                    result = calc.Multiply(firstNum, secondNum);
                    Console.WriteLine("{0} * {1}", firstNum, secondNum);
                    break;
                case (4):
                    result = calc.Divide(firstNum, secondNum);
                    Console.WriteLine("{0} / {1}", firstNum, secondNum);
                    break;
                case (5):
                    result = calc.Sqrt(firstNum);
                    Console.WriteLine("Sqrt({0})", firstNum);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("operationNumber", "Операция с таким номером не определена");
            }

            return result;
        }

        private static double UserInputDouble()
        {
            string userInput;
            double result;
            while (true)
            {
                userInput = Console.ReadLine();
                if (double.TryParse(userInput, out result))
                {
                    break;
                }
                Console.WriteLine("Не удаётся. Необходимо ввести число. Для отделения целой части от вещественной используйте точку: 1234.5678");
            }
            return result;
        }
    }
}

