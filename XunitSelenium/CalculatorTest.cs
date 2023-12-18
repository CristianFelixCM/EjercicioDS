using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace calculator.test.xunit
{
    public class CalculatorTest
    {

        private void EvaluateOperation(int a, int b, string operation, double result)
        {
            //create a new instance of selenium
            IWebDriver driver = new ChromeDriver();
            //navegate to the url
            driver.Navigate().GoToUrl("http://localhost:5136/Calculator");

            IWebElement varlorA = driver.FindElement(By.Id("A_TheNumber"));
            IWebElement Operacion = driver.FindElement(By.Id("Command"));
            IWebElement valorB = driver.FindElement(By.Id("B_TheNumber"));
            IWebElement boton = driver.FindElement(By.XPath("//input[@type='submit']"));

            varlorA.SendKeys(a.ToString());
            Operacion.SendKeys(operation);
            valorB.SendKeys(b.ToString());
            boton.Click();
            var outputResultString = driver.FindElement(By.XPath("//td[@id='theResult']")).Text;
            Assert.True(double.TryParse(outputResultString, out double outputResult));
            Assert.True(result == outputResult);
        }

        [Theory(DisplayName = "Operations Theory")]
        [Trait("TestType", "Functional Theories")]
        [InlineData(1, "+", 2, 3)]
        [InlineData(10, "x", 4, 40)]
        [InlineData(20, "/", 4, 5)]
        [InlineData(20, "-", 4, 16)]
        [InlineData(10, "/", 4, 2.5)]
        public void OperationsTheory(int a, string operation, int b, double result)
        {
            EvaluateOperation(a, b, operation, result);
        }


        [Theory(DisplayName = "Number Properties Prime Number Theory")]
        [Trait("TestType", "Functional Theories")]
        [InlineData(13, true, false, false)]
        [InlineData(86743, true, false, false)]
        [InlineData(1, false, true, false)]
        [InlineData(8, false, true, false)]
        [InlineData(369, false, true, false)]
        [InlineData(0, false, false, true)]
        public void PrimeNumberTest(int number, bool isPrime, bool isNotPrime, bool isUndefined)
        {
            //create a new instance of selenium
            IWebDriver driver = new ChromeDriver();
            //navegate to the url
            driver.Navigate().GoToUrl("http://localhost:5136/NumberProperties");
            var numberXPath = @"//input[@id='TheNumber']";
            var submitButton = "//input[@type='submit']";
            IWebElement inputA = driver.FindElement(By.Id("TheNumber"));
            IWebElement button = driver.FindElement(By.XPath("//input[@type='submit']"));
            inputA.SendKeys(number.ToString());
            button.Click();
            IWebElement isPrimeNumberMark = driver.FindElement(By.Id("isPrimeNumber"));
            IWebElement isNotPrimeNumberMark = driver.FindElement(By.Id("IsNotPrimeNumber"));
            IWebElement isUndefinedMark = driver.FindElement(By.Id("IsUndefined"));
            var isPrimeNumberMarkText = isPrimeNumberMark.Text == "X";
            var isNotPrimeNumberMarkText = isNotPrimeNumberMark.Text == "X";
            var isUndefinedMarkText = isUndefinedMark.Text == "X";
            Assert.True(isPrime == isPrimeNumberMarkText);
            Assert.True(isNotPrime == isNotPrimeNumberMarkText);
            Assert.True(isUndefined == isUndefinedMarkText);
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
            //create a new instance of selenium
            IWebDriver driver = new ChromeDriver();
            //navegate to the url
            driver.Navigate().GoToUrl("http://localhost:5136/Calculator");

            IWebElement varlorA = driver.FindElement(By.Id("A_TheNumber"));
            IWebElement boton = driver.FindElement(By.XPath("//input[@type='submit']"));

            varlorA.SendKeys(a.ToString());
            boton.Click();
            var outputResultString = driver.FindElement(By.XPath("//td[@id='theResult']")).Text;

            Assert.True(Operator.raiz(a) == result);
        }

    }
}