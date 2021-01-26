using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjSpace
{
    class NewDealOrderPage_PageObj : NewDealPage_PageObj
    {
        new public NewDealOrderPage_PageObj check_all_Div()
        {
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]")).Click();
            return new NewDealOrderPage_PageObj(_webDriver);
        }
        public NewDealOrderPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        public OrderShipmentForm_PageObj open_shipment_form() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/a")).Click();
            return new OrderShipmentForm_PageObj(_webDriver);
        } 
    }
}
