using NUnit.Framework;
using OpenQA.Selenium;
using PageObjSpace;
using System.Threading;

namespace TestCRM
{
    public class Tests
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            _webDriver.Navigate().GoToUrl("http://crm.sibelcom.tech/");
            _webDriver.Manage().Window.Maximize();
        }
        [Test]
        public void Login_Test()
        {
            LoginPage_PageObj login_Form = new LoginPage_PageObj(_webDriver);
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
                    Assert.IsTrue(false, LoginPage_PageObj.arr_data[i].email + " " + LoginPage_PageObj.arr_data[i].pass + " - is not valid data!");
                }
            }
            Assert.Pass();
        }
        [Test]
        public void NewDealTest()
        {
            new LoginPage_PageObj(_webDriver).Sign_in(0)
                .go_to_deal()
                .New_Deal()
                .fill_newdeal_form()
                .add_deal()
                .add_product()
                .add_product_list()
                .fill_list();
            Assert.Pass();
        }
        [Test]
        public void SupplyTest()
        {
            LoginPage_PageObj login_Form = new LoginPage_PageObj(_webDriver);
            //Create deal 
            login_Form.Sign_in(0)
                .go_to_deal()
                .New_Deal()
                .fill_newdeal_form()
                .add_deal()
                .add_product()//Реализовать превязку каждого цикла добавления товаров к длинне массива с товарами
                .add_product_list()
                .fill_list()
                .request_supply()
                .send_request();
            //Execute id deals
            string deal_id = _webDriver.FindElement(By.XPath("//input[@data-id='" + _webDriver.Url.Substring(_webDriver.Url.LastIndexOf("=") + 1) + "']")).GetAttribute("value");
            //Work with deal from it id on a deal page
            (new NewDealPage_PageObj(_webDriver))
                .exit()
                .Sign_in(1)
                .go_to_supply(deal_id)
                .open_supply_deal()
                .take_in_work();
        }
        [Test]
        public void NewWindowDealTest(){
            (new LoginPage_PageObj(_webDriver)).Sign_in(0)
                    .go_to_deal()
                    .New_Deal()
                    .check_all_Div()
                    .fill_newdeal_form()
                    .add_deal()
                    .add_product()
                    .add_product_list()
                    .check_all_Div()
                    .fill_list();
        }
        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
            //закрытие
        }
    }
}
