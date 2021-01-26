using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjSpace
{
    class NewDealInfoPage_PageObj : NewDealPage_PageObj
    {
        new public NewDealInfoPage_PageObj check_all_Div()
        {
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]")).Click();
            return new NewDealInfoPage_PageObj(_webDriver);
        }
        public NewDealInfoPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        public InfoRedactCheckedForm_PageObj open_redact_checked() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/a[1]")).Click();
            return new InfoRedactCheckedForm_PageObj(_webDriver);
        }
        public InfoRedactListForm_PageObj open_redact_list()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/a[2]")).Click();
            return new InfoRedactListForm_PageObj(_webDriver);
        }
    }
}
