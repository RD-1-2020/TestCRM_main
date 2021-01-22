using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
namespace Prj_test.PageObjects
{
    class SupplyPage_PageObj : NavigationBar_PageObj
    {
         
        static private string deal_id;
        public SupplyPage_PageObj(IWebDriver webDriver, string _deal_id) : base(webDriver)
        {
            deal_id = _deal_id;
        }
        /// <summary>
        /// Open a deal page from it id
        /// </summary>
        /// <returns>Redirect on a SupplyDealPage(deal id = deal_id)</returns>
        public SupplyDealPage_PageObj open_supply_deal() {
            _webDriver.FindElement(By.XPath("//a[text()='" + deal_id + "_s" + "']")).Click();
            return new SupplyDealPage_PageObj(_webDriver, deal_id);
        }
       
        
    }
}
