using NUnit.Framework;
using OpenQA.Selenium;
using Prj_test.PageObjects;

namespace TestCRM
{
    /// <summary>
    /// Шаблон для тестов
    /// </summary>
    public abstract class TestTemplates
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()

        {
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            driver.Navigate().GoToUrl("http://crm.sibelcom.tech/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public abstract void Test1();
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            //закрытие
        }
    }
}
