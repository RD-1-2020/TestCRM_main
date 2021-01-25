﻿using System;
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
        public Product_List_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Fill the list
        /// </summary>
        /// <returns>Redirect on a newdealpage</returns>
        public NewDealPage_PageObj fill_list() {
            for (int i = new Random().Next(NavigationBar_PageObj.products.Length*2/3, NavigationBar_PageObj.products.Length); i < NavigationBar_PageObj.products.Length; i++)
            {
                _webDriver.FindElement(textarea_partno).SendKeys(products[i].PartNum+"\n");
                _webDriver.FindElement(textarea_count).SendKeys(products[i].count + "\n");
                _webDriver.FindElement(textarea_category).SendKeys(products[i].category + "\n");
            }
            _webDriver.FindElement(button_add).Click();
            return new NewDealPage_PageObj(_webDriver);
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
        public NewDealPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Add product with list
        /// </summary>
        /// <returns>Redirect on a Product list</returns>
        public Product_List_PageObj add_product_list()
        {
            _webDriver.FindElement(button_product).Click();
            _webDriver.FindElement(button_product_list).Click();
            return new Product_List_PageObj(_webDriver);
        }
        /// <summary>
        /// requets in supply on a supply page(go to-> supply form)
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
        public NewDealPage_PageObj add_product() {
            for (int i = new Random().Next(NavigationBar_PageObj.products.Length/3, NavigationBar_PageObj.products.Length*2/3); i < NavigationBar_PageObj.products.Length*2/3; i++)
            {
                _webDriver.FindElement(button_product).Click();
                _webDriver.FindElement(textarea_product_partno).SendKeys(products[i].PartNum);
                _webDriver.FindElement(textarea_product_count).SendKeys(products[i].count);
                _webDriver.FindElement(button_product_add).Click();
            }
            return new NewDealPage_PageObj(_webDriver);
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
        /// 

       //хер его знает как это проверить
        
        /* public bool partNo_assert() {
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
        } */
    }
}
