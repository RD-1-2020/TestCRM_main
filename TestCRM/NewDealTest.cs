using NUnit.Framework;
using OpenQA.Selenium;
using Prj_test.PageObjects;
using System.Threading;
namespace TestCRM
{
    public class NewDealTest
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            driver.Navigate().GoToUrl("http://crm.sibelcom.tech/");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test1()
        {
            new LoginPage_PageObj(driver).Sign_in(0)
                .go_to_deal()
                .New_Deal()
                .fill_newdeal_form()
                .add_deal()
                .add_product()
                .add_product_list()
                .fill_list();
            Assert.Pass("Партномер товара соответствует партномеру указаному в структуре в новой сделке 0");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            //закрытие
        }
    }
}
