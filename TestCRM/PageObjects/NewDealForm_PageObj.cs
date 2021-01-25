using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
namespace PageObjSpace
{
    public class NewDealForm_PageObj : NavigationBar_PageObj
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
        public NewDealForm_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }

        /// <summary>
        /// Fill new deal form
        /// </summary>
        /// <returns></returns>
        public NewDealForm_PageObj fill_newdeal_form()
        {
            _webDriver.FindElement(list_client).Click();
            _webDriver.FindElement(By.XPath("//div[@data-id=" + client_id + "]")).Click();
            _webDriver.FindElement(area_comment).SendKeys(rand_string(100));
            for (int i = new Random().Next(products.Length / 3); i < products.Length / 3; i++)
            {
                _webDriver.FindElement(area_product).SendKeys(products[i].PartNum +
                    "*" + products[i].count + "\n");
            }
            return new NewDealForm_PageObj(_webDriver);
        }
        /// <summary>
        /// Post deal fill add deal
        /// </summary>
        /// <returns>Redirect on a deal page</returns>
        public NewDealPage_PageObj add_deal()
        {
            _webDriver.FindElement(button_new_deal).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
    }
}
