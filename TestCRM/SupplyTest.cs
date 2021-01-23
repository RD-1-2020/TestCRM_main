using System;
using System.Collections.Generic;
using System.Text;
using TestCRM;
using OpenQA.Selenium;
using Prj_test.PageObjects;
using System.Threading;
using NUnit.Framework;

namespace Prj_test
{
    class SupplyTest
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
            //Create deal 
            Assert.True(login_Form.Sign_in(0)
                .go_to_deal()
                .New_Deal()
                .fill_newdeal_form()
                .add_deal()
                .add_product()
                .add_product_list()
                .fill_list()
                .request_supply()
                .send_request()
                .partNo_assert(),
                "Товар не добавлен к сделке");
            //Execute id deals
            string deal_id = driver.FindElement(By.XPath("//input[@data-id='" + driver.Url.Substring(driver.Url.LastIndexOf("=") + 1) + "']")).GetAttribute("value");
            //Work with deal from it id on a deal page
            (new NewDealPage_PageObj(driver))
                .exit()
                .Sign_in(1)
                .go_to_supply(deal_id)
                .open_supply_deal()
                .take_in_work();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            //закрытие
        }
    }
}
