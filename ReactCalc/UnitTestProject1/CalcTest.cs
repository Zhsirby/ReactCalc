using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactCalc;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calc();
            var x = calc.Sum(1, 2);

            Assert.AreEqual(x, 3);
            Assert.AreEqual(calc.Sum(0, 0), 0);
            Assert.AreEqual(calc.Sum(-1, 2), 1);
            Assert.AreNotEqual(calc.Sum(-10, 2), 3);
        }
        [TestMethod]
        public void TestDivide()
        {
            var calc = new Calc();
            var x = calc.Divide(4, 2);

            Assert.AreEqual(x, 2);
        }
        [TestMethod]
        public void TestSqrt()
        {
            var calc = new Calc();
            var x = calc.Sqrt(4);

            Assert.AreEqual(x, 2);
        }
        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc();
            var x = calc.Pow(4, 2);

            Assert.AreEqual(x, 16);
        }
    }
}
