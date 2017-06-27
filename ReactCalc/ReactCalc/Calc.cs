using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    public class Calc
    {
        
        public double Sum(double x, double y)
        {
            return (x + y);
        }

        public double Subtract(double x, double y)
        {
            return (x - y);
        }

        public double Multiplication(double x, double y)
        {
            return x * y;       
        }
        
        public double Divide(double x, double y)
        {
            return x / y;
        }

        public double SqrtNumber(double x, double y)
        {
            double z = 0;
            z = x + y;
            return Math.Sqrt(z);
        }
    }
}
