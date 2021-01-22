using NUnit.Framework;
using OpenQA.Selenium;
namespace NewDealTestList
{
    public class NewDeal
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            driver.Navigate().GoToUrl("http://crm.sibelcom.tech/");
            driver.Manage().Window.Maximize();
            By button_sign = By.XPath("//input[@name='submit']");
            By input_email = By.XPath("//input[@name='email']");
            By input_pass = By.XPath("//input[@type='password']");
            var Button_sign = driver.FindElement(button_sign);
            var Input_email = driver.FindElement(input_email);
            var Input_pass = driver.FindElement(input_pass);
            Input_email.SendKeys("testing@sibelcom54.com");
            Input_pass.SendKeys("Test2020!");
            Button_sign.Click();
        }
        [Test]
        public void Test1()
        {
            By button_deal = By.XPath("//a[@href='/index.php?require=deal']");
            var Button_deal = driver.FindElement(button_deal);
            Button_deal.Click();
        }
    }
}