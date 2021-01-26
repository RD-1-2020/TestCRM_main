using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;

namespace PageObjSpace
{
     class NewDealPage_PageObj : NavigationBar_PageObj
    {
        private readonly By button_product = By.XPath("//a[@data-toggle='.deal-proposal-add']");

        private readonly By button_product_list = By.XPath("//a[text()='Добавить списком']");
        private readonly By button_product_add = By.XPath("//input[@value='добавить']");
        private readonly By button_Import_XLS = By.XPath("//a[text()='Импорт XLS']");
        private readonly By textarea_product_partno = By.XPath("//input[@id='deal-product-form-partNo']");
        private readonly By textarea_product_count = By.XPath("//input[@id='deal-product-form-amount']");

        private readonly By button_supply = By.XPath("//a[@data-toggle='.deal-supply-pop']");
        private readonly By button_supply_request = By.XPath("//a[text()='Заявка в снабжение']");
        /// <summary>
        /// номер сделки
        /// </summary>
        public NewDealPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Add product with list
        /// </summary>
        /// <returns>Redirect on a Product list</returns>
        public ProductListForm_PageObj add_product_list()
        {
            _webDriver.FindElement(button_product).Click();
            _webDriver.FindElement(button_product_list).Click();
            return new ProductListForm_PageObj(_webDriver);
        }
        /// <summary>
        /// add product use a xls import
        /// </summary>
        /// <returns></returns>
        public ImportXLSForm_PageObj add_product_ImportXLS()
        {
            _webDriver.FindElement(button_Import_XLS).Click();
            return new ImportXLSForm_PageObj(_webDriver);
        }
        /// <summary>
        /// requets in supply on a supply page(go to-> supply form)
        /// </summary>
        public SupplyForm_PageObj request_supply()
        {
            _webDriver.FindElement(button_supply).Click();
            _webDriver.FindElement(button_supply_request).Click();
            return new SupplyForm_PageObj(_webDriver);
        }
        /// <summary>
        /// Add product on page
        /// </summary>
        /// <returns></returns>
            public NewDealPage_PageObj add_product()
        {
            for (int i = new Random().Next(products.Length / 3, products.Length * 2 / 3); i < products.Length * 2 / 3; i++)
            {
                _webDriver.FindElement(button_product).Click();
                _webDriver.FindElement(textarea_product_partno).SendKeys(products[i].PartNum);
                _webDriver.FindElement(textarea_product_count).SendKeys(products[i].count);
                _webDriver.FindElement(button_product_add).Click();
            }
            return new NewDealPage_PageObj(_webDriver);
        }
            public NewDealPage_PageObj click_on_chip() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/a")).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
            public DealRedactCheckedForm_PageObj redact_checked() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/menu/li[1]/a")).Click();
            return new DealRedactCheckedForm_PageObj(_webDriver);
        }
            public ComplexProductForm_pageObj ComplexProduct_from_checked()
        {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/menu/li[2]/a")).Click();
            return new ComplexProductForm_pageObj(_webDriver);
        }
            public ComplexProductXLSForm_PageObj ComplexProduct_from_XLS(){
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[5]/div/menu/li[3]/a")).Click();
            return new ComplexProductXLSForm_PageObj(_webDriver);
        }
            public NewDealPage_PageObj go_to_dealpage() {
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/a[1]")).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
            public NewDealOfferPage_PageObj go_to_offer() {
            _webDriver.FindElement(By.XPath("//a[text()='Предложение']")).Click();
            return new NewDealOfferPage_PageObj(_webDriver);
        }
            public NewDealOrderPage_PageObj go_to_order(){
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/a[3]")).Click();
            return new NewDealOrderPage_PageObj(_webDriver);
        }
            public NewDealInfoPage_PageObj go_to_info(){
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[1]/a[4]")).Click();
            return new NewDealInfoPage_PageObj(_webDriver);
        }
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
