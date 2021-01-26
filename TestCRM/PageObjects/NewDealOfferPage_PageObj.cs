using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjSpace
{
    class NewDealOfferPage_PageObj : NewDealPage_PageObj
    {

        new public NewDealOfferPage_PageObj check_all_Div()
        {
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]")).Click();
            return new NewDealOfferPage_PageObj(_webDriver);
        }
        public NewDealOfferPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        public NewDealOfferPage_PageObj Open_Offer_Menu()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/a")).Click();
            return new NewDealOfferPage_PageObj(_webDriver);
        }
        public OfferProviderForm_PageObj Add_offer_Provider() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/a[1]")).Click();
            return new OfferProviderForm_PageObj(_webDriver);
        }
        public OfferListForm_PageObj Add_offer_List()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/a[2]")).Click();
            return new OfferListForm_PageObj(_webDriver);
        }
        public OfferXLSForm_PageObj Add_offer_XLS()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/a[3]")).Click();
            return new OfferXLSForm_PageObj(_webDriver);
        }
        
    }
}
