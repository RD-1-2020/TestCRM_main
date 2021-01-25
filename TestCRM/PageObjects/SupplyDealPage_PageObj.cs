using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjSpace
{
    public class SupplyDealPage_PageObj : NavigationBar_PageObj
    {
        private readonly By button_take_in_work = By.XPath("//a[text()='Взять в работу']");

        private readonly By button_request_provider = By.XPath("//span[text()='Отправить заявку поставщику']");
        //Реализовать!!!
        /* public ProviderRequestForm_PageObj request_provider() { 

         }*/
        private string deal_id;
        public SupplyDealPage_PageObj(IWebDriver webDriver, string id) : base(webDriver)
        {
            deal_id = id;
        }
        public SupplyDealPage_PageObj take_in_work()
        {
            _webDriver.FindElement(button_take_in_work).Click();
            return new SupplyDealPage_PageObj(_webDriver, deal_id);
        }
    }
}
