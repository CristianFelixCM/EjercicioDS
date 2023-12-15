using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace calculator.test.xunit
{
    public class CalculatorTestCucumber(ScenarioContext scenarioContext)
    {

        private double EvaluateOperation(int a, int b, string operation)
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
            return double.Parse(outputResultString);
        }

        private readonly ScenarioContext _scenarioContext = scenarioContext;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int firstNumber)
        {
            _scenarioContext.Add("FirstNumber", firstNumber);
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int secondNumber)
        {
            _scenarioContext.Add("SecondNumber", secondNumber);
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "+"));
        }

        [Then(@"the result should be (.*)")]
        [Then(@"the result shall be (.*)")]
        public void ThenTheResultShouldBe(double result)
        {
            Assert.True(result == _scenarioContext.Get<double>("Result"));
        }

        [When(@"I substract first number to second number")]
        public void WhenISubstractFirstNumberToSecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "-"));
        }

        [When(@"I multiply both numbers")]
        public void WhenIMultiplyBothNumbers()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "x"));
        }

        [When(@"I divide first number by second number")]
        public void WhenIDivideFirstNumberBySecondNumber()
        {
            var firstNumber = _scenarioContext.Get<int>("FirstNumber");
            var secondNumber = _scenarioContext.Get<int>("SecondNumber");
            _scenarioContext.Add("Result", EvaluateOperation(firstNumber, secondNumber, "/"));
        }


        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(double result)
        {
            Assert.True(result == _scenarioContext.Get<double>("Result"));
        }


    }
}