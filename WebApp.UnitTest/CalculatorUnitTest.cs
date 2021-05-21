using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;

namespace WebApp.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void TestAdd()
        {
            //A: Arrangement
            Calculator calc = new Calculator();
            int num1 = 2, num2 = 6;

            //A:Action
            int result = calc.Add(2, 6);

            //A:Assert
            Assert.AreEqual(num1 + num2, result);
        }
    }
}
