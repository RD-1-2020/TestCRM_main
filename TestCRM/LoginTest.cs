using NUnit.Framework;
using OpenQA.Selenium;
using Prj_test.PageObjects;

namespace TestCRM
{
    public class LoginTest
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
            LoginPage_PageObj login_Form = new LoginPage_PageObj(driver);
            for (int i = 0; i < login_Form.Length; i++)
            {
                try
                {
                    login_Form
                    .Sign_in(i)
                    .exit()
                    ;
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Assert.IsTrue(false, LoginPage_PageObj.Logs.arr_data[i].email + " " + LoginPage_PageObj.Logs.arr_data[i].email + " - is not valid data!");
                }
            }
            Assert.Pass();
        }
        [TearDown]
        public void TearDown(){
            driver.Quit();
            //закрытие
        }
    }
}