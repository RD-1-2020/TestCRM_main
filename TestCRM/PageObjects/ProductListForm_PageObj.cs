using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace PageObjSpace
{
    class ProductListForm_PageObj : NavigationBar_PageObj
    {
        private readonly By textarea_count = By.XPath("//textarea[@name='amount']");
        private readonly By textarea_partno = By.XPath("//textarea[@name='partNo']");
        private readonly By textarea_category = By.XPath("//textarea[@name='productCategory']");
        private readonly By button_add = By.XPath("//input[@value='Добавить']");
        public ProductListForm_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Fill the list
        /// </summary>
        /// <returns>Redirect on a newdealpage</returns>
        public NewDealPage_PageObj fill_list()
        {
            for (int i = new Random().Next(products.Length * 2 / 3, products.Length); i < products.Length; i++)
            {
                _webDriver.FindElement(textarea_partno).SendKeys(products[i].PartNum + "\n");
                _webDriver.FindElement(textarea_count).SendKeys(products[i].count + "\n");
                _webDriver.FindElement(textarea_category).SendKeys(products[i].category + "\n");
            }
            _webDriver.FindElement(button_add).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
        public ProductListForm_PageObj check_all_Div()
        {
            check_div(_webDriver);
            return new ProductListForm_PageObj(_webDriver);
        }
    }

    
}
