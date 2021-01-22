using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
namespace Prj_test.PageObjects
{
    class NewDealForm_PageObj
    {
        //Execute numdeal element
        private readonly By input_numdeal = By.XPath("//input[@id='undefined-title']");
        //element
        private readonly By button_new_deal = By.XPath("//input[@class='button add']");
        private readonly By list_client = By.XPath("//input[@id='undefined-company']");
        private readonly By area_comment = By.XPath("//textarea[@name='comment']");
        private readonly By area_product = By.XPath("//textarea[@name='partNo']");
        /// <summary>
        /// Number deal 
        /// </summary>
        private int num_deal;
        private IWebDriver _webDriver;
        public NewDealForm_PageObj(IWebDriver webDriver, int _numdeal) {
            _webDriver = webDriver;
            num_deal = _numdeal;

        }
        /// <summary>
        /// Fill new deal form
        /// </summary>
        /// <param name="numdeal">Number deal from deals(NavigationBar_PageObj)</param>
        /// <returns></returns>
        
        public NewDealForm_PageObj fill_newdeal_form() {
            Thread.Sleep(1000);
            _webDriver.FindElement(list_client).Click();
            _webDriver.FindElement(By.XPath("//div[@data-id="+ NavigationBar_PageObj.client_id+"]")).Click();
            _webDriver.FindElement(area_comment).SendKeys("Comment");
            for (int i = 0; i < 2; i++)
            {
                _webDriver.FindElement(area_product).SendKeys(NavigationBar_PageObj.products[i].PartNum +
                    "*" + NavigationBar_PageObj.products[i].count + "\n");
            }
            return new NewDealForm_PageObj(_webDriver, num_deal);
        }
        /// <summary>
        /// Post deal fill add deal
        /// </summary>
        /// <returns>Redirect on a deal page</returns>
        public NewDealPage_PageObj add_deal() {
            _webDriver.FindElement(button_new_deal).Click();
            return new NewDealPage_PageObj(_webDriver, num_deal);
        } 
    }
}
