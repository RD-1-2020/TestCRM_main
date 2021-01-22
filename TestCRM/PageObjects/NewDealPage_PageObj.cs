using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;

namespace Prj_test.PageObjects
{
    class Product_List_PageObj:NavigationBar_PageObj
    {
        private readonly By textarea_count = By.XPath("//textarea[@name='amount']");
        private readonly By textarea_partno = By.XPath("//textarea[@name='partNo']");
        private readonly By textarea_category = By.XPath("//textarea[@name='productCategory']");
        private readonly By button_add = By.XPath("//input[@value='Добавить']");
        private int num_deal;
        public Product_List_PageObj(IWebDriver webDriver, int numdeal) : base(webDriver)
        {
            num_deal = numdeal;
        }
        /// <summary>
        /// Fill the list
        /// </summary>
        /// <returns>Redirect on a newdealpage</returns>
        public NewDealPage_PageObj fill_list0() {
            _webDriver.FindElement(textarea_partno).SendKeys(products[3].PartNum);
            _webDriver.FindElement(textarea_count).SendKeys(products[3].count);
            _webDriver.FindElement(textarea_category).SendKeys(products[3].category);
            _webDriver.FindElement(button_add).Click();
            return new NewDealPage_PageObj(_webDriver, num_deal);
        }
    }
    class NewDealPage_PageObj : NavigationBar_PageObj
    {
        private readonly By button_product = By.XPath("//a[@data-toggle='.deal-proposal-add']");

        private readonly By button_product_list = By.XPath("//a[text()='Добавить списком']");
        private readonly By button_product_add = By.XPath("//input[@value='добавить']");
        private readonly By textarea_product_partno = By.XPath("//input[@id='deal-product-form-partNo']");
        private readonly By textarea_product_count = By.XPath("//input[@id='deal-product-form-amount']");

        private readonly By button_supply = By.XPath("//a[@data-toggle='.deal-supply-pop']");
        private readonly By button_supply_request = By.XPath("//a[text()='Заявка в снабжение']");
        /// <summary>
        /// номер сделки
        /// </summary>
        private int num_deal;
        public NewDealPage_PageObj(IWebDriver webDriver, int _numdeal) : base(webDriver)
        {
            num_deal = _numdeal;
        }
        /// <summary>
        /// Add product with list
        /// </summary>
        /// <returns>Redirect on a Product list</returns>
        public Product_List_PageObj add_product_list()
        {
            _webDriver.FindElement(button_product).Click();
            _webDriver.FindElement(button_product_list).Click();
            return new Product_List_PageObj(_webDriver, num_deal);
        }
        /// <summary>
        /// requets in supply
        /// </summary>
        public SupplyForm_PageObj request_supply() {
            _webDriver.FindElement(button_supply).Click();
            _webDriver.FindElement(button_supply_request).Click();
            return new SupplyForm_PageObj(_webDriver, num_deal);
        }
        /// <summary>
        /// Add product on page
        /// </summary>
        /// <returns></returns>
        public NewDealPage_PageObj add_product0() {
            _webDriver.FindElement(button_product).Click();
            _webDriver.FindElement(textarea_product_partno).SendKeys(products[2].PartNum);
            _webDriver.FindElement(textarea_product_count).SendKeys(products[2].count);
            _webDriver.FindElement(button_product_add).Click();
            return new NewDealPage_PageObj(_webDriver, 0);
        }
        /*public bool int_count_assert()
        {
            try
            {
                for (int i = 0; i < deals[num_deal].products.partNo.Length - 1; i++)
                {
                _webDriver.FindElement(By.XPath("//input[@value='" + deals[num_deal].products.count[i] + ".00']"));
                }
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }*/
        /// <summary>
        /// Check partnumber
        /// </summary>
        /// <returns>If all is good - true, else - false</returns>
        public bool partNo_assert() {
            try
            {
                for (int i=0; i < products.Length; i++)
                {
                    try
                    {

                        _webDriver.FindElement(By.XPath("//span[text()='" + products[i].category + " " + products[i].PartNum + "']"));

                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        _webDriver.FindElement(By.XPath("//span[text()='" + "(без категории) " + products[i].PartNum + "']"));
                    }
                }
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException) {
                return false;
            }
        } 
    }
}
