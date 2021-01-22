using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
namespace Prj_test.PageObjects
{
    /// <summary>
    /// init navbar
    /// </summary>
    class NavigationBar_PageObj
    {
        protected IWebDriver _webDriver;

        private readonly By button_calendar = By.XPath("//a[text()='Календарь']");
        private readonly By button_clients = By.XPath("//a[text()='Клиенты']");
        private readonly By button_providers = By.XPath("//a[text()='Поставщики']");
        private readonly By button_deal = By.XPath("//a[text()='Сделки']");
        private readonly By button_supply = By.XPath("//a[text()='Снабжение']");
        private readonly By button_RFQ = By.XPath("//a[text()='RFQ']");
        private readonly By button_score = By.XPath("//a[text()='Счета']");
        private readonly By button_shipments = By.XPath("//a[text()='Отгрузки']");

        private readonly By button_products = By.XPath("//a[text()='Продукция']");
        private readonly By button_products_manufactorer = By.XPath("//a[text()='Производители']");
        private readonly By button_products_product = By.XPath("//a[text()='Товар']");
        private readonly By button_products_moderator = By.XPath("//a[text()='Модерация']");
        private readonly By button_products_categores = By.XPath("//a[text()='Категории']");
        private readonly By button_products_bodies = By.XPath("//a[text()='Корпусы']");

        private readonly By button_statics = By.XPath("//a[text()='Статистика']");
        private readonly By button_statics_calls = By.XPath("//a[text()='Звонки']");
        private readonly By button_statics_score = By.XPath("//a[text()='Счета']");


        private readonly By button_documents = By.XPath("//a[text()='Документы']");
        private readonly By button_documents_archive = By.XPath("//a[text()='Архив']");
        private readonly By button_documents_templates = By.XPath("//a[text()='Шаблоны документов']");

        private readonly By button_warehouse = By.XPath("//a[text()='Склад']");
        private readonly By button_warehouse_sibelcom = By.XPath("//a[text()='СибЭлком']");
        private readonly By button_warehouse_admissions = By.XPath("//a[text()='Приёмки']");
        private readonly By button_warehouse_admin = By.XPath("//a[text()='Склад адм.']");
        private readonly By button_warehouse_M15 = By.XPath("//a[text()='M15']");

        //Работа с кучей товаров массивы строк
        public class Product
        {
            public string[] partNo { get; set; }
            public string[] category { get; set; }
            public string[] count { get; set; }
            public Product(string[] _partNo, string[] _category, string[] _count)
            {
                partNo = _partNo;
                category = _category;
                count = _count;
            }
        }
        public struct deal
        {
            public string id_client;
            public string comment;
            public Product products;
            /// <summary>
            /// Construct deal
            /// </summary>
            /// <param name="id_client">Client Id</param>
            /// <param name="comment">Comment(rand)</param>
            /// <param name="partNo">Product partNumber</param>
            public deal(string id_client, string comment, string[] partNo, string[] category, string[] count)
            {
                this.id_client = id_client;
                this.comment = comment;
                products = new Product(partNo, category, count);
            }
        }

        public static string[] deal0_PartNo = { "КабельТест", "РезисторТест", "КонденсаторТест", "Припой тест" };
        public static string[] deal0_category = { "Кабель", "Резистор", "Конденсатор", "Припой" };
        public static string[] deal0_count = { "53", "132", "231", "440" };
        /// <summary>
        /// Deal with info about 
        /// </summary>
        public static deal[] deals = {
            new deal("'598'","Comment",deal0_PartNo,deal0_category,deal0_count)
        };

        private readonly By button_exit = By.XPath("//a[@href='index.php?log_out=now']");

        public NavigationBar_PageObj(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            ///Check a body text
            String bodyText = _webDriver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.IndexOf("Notice") == -1, "body pf page have a notice");
            Assert.IsTrue(bodyText.IndexOf("Fatall Error") == -1, "body pf page have a fatall error");
            Assert.IsTrue(bodyText.IndexOf("Warning") == -1, "body pf page have a warning");
            Assert.IsTrue(bodyText.IndexOf("Error") == -1, "body pf page have a error");
        }

        /// <summary>
        /// click on button_deal
        /// </summary>
        /// <returns>Redirect on deal_page</returns>
        public DealPage_PageObj go_to_deal()
        {
            _webDriver.FindElement(button_deal).Click();
            return new DealPage_PageObj(_webDriver);
        }
        /// <summary>
        /// redirect on supply page
        /// </summary>
        /// <param name="id">Id of a deal, which you create</param>
        /// <returns>Redirect on a supply page</returns>
        public SupplyPage_PageObj go_to_supply(string id)
        {
            _webDriver.FindElement(button_supply).Click();
            return new SupplyPage_PageObj(_webDriver, id);
        }
        //Доработать
        public void go_to_manufactorer()
        {
            _webDriver.FindElement(button_products).Click();
            _webDriver.FindElement(button_products_manufactorer).Click();
        }
        /// <summary>
        /// exit now user
        /// </summary>
        /// <returns>Redirect from Login_frormPageobj</returns>
        public LoginPage_PageObj exit()
        {
            _webDriver.FindElement(button_exit).Click();
            return new LoginPage_PageObj(_webDriver);
        }
    }
}
