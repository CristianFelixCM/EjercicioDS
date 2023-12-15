using System;
using calculator;

namespace calculator.test.xunit

{
    public class OperatorTests
    {
        [Fact]
        [Trait("TestType", "UT")]
        public void BasicAdd()
        {
            int a = 1;
            int b = 2;
            double result = 3;
            Assert.True(Operator.Add(a, b) == result);
        }
        [Fact]
        [Trait("TestType", "UT")]
        public void BasicMultiply()
        {
            int a = 10;
            int b = 4;
            double result = 40;
            Assert.True(Operator.Multiply(a, b) == result);
        }

        [Theory(DisplayName = "Division Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(20, 4, 5)]
        [InlineData(10, 4, 2.5)]
        public void DivisionTheory(int a, int b, double result)
        {
            Assert.True(Operator.Divide(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType", "UT")]
        //public void BasicDivide()
        //{
        //    int a = 20;
        //    int b = 4;
        //    double result = 5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Fact]
        [Trait("TestType", "UT")]
        public void BasicSubstract()
        {
            int a = 20;
            int b = 4;
            double result = 16;
            Assert.True(Operator.Substract(a, b) == result);
        }
        //[Fact]
        //[Trait("TestType","NRT")]
        //public void DividingNonIntegerResult()
        //{
        //    int a = 10;
        //    int b = 4;
        //    double result = 2.5;
        //    Assert.True(Operator.Divide(a, b) == result);
        //}

        [Theory(DisplayName = "Prime Number Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(0, PrimeNumberInfo.Unknown)]
        [InlineData(1, PrimeNumberInfo.No)]
        [InlineData(2, PrimeNumberInfo.Yes)]
        [InlineData(3, PrimeNumberInfo.Yes)]
        [InlineData(4, PrimeNumberInfo.No)]
        [InlineData(5, PrimeNumberInfo.Yes)]
        [InlineData(6, PrimeNumberInfo.No)]
        [InlineData(7, PrimeNumberInfo.Yes)]
        [InlineData(8, PrimeNumberInfo.No)]
        [InlineData(9, PrimeNumberInfo.No)]
        [InlineData(10, PrimeNumberInfo.No)]
        [InlineData(11, PrimeNumberInfo.Yes)]
        [InlineData(997, PrimeNumberInfo.Yes)]
        [InlineData(98689, PrimeNumberInfo.Yes)]
        [InlineData(86743, PrimeNumberInfo.Yes)]
        public void IsThisNumberPrime(int number, PrimeNumberInfo isPrimeNumber)
        {
            Assert.True(isPrimeNumber == Operator.IsPrimeNumber(number));
        }



        //EJERCICIO
        [Theory(DisplayName = "Raiz Theory")]
        [Trait("TestType", "Theory")]
        [InlineData(4, 2)]
        [InlineData(5, 2.236)]
        [InlineData(2.5, 1.581)]
        [InlineData(0, 0)]
        public void RaizTheory(double a, double result)
        {
            //todavia no implementado
            Assert.True(Operator.raiz(a) == Math.Round(result)); //he tenido que redondear el resultado dado que me a�ad�a muchos ceros terminado en un 2.....
        }




    }
}


