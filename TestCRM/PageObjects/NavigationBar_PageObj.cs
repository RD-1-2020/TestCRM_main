using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
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
        
        protected class Product
        {
            protected string id_client;
            protected string PartNum;
            protected string category;
            protected string count;
            protected string weight;
            static int n;
           public struct answer
            {
                string id_provider;
                string price;
                string delivery_time;
                string add1;
                string add2;
                string curence;
                
                public answer(string id_provider, string price, string delivery_time, string add1, string add2, string curence)
                {
                    this.id_provider = id_provider;
                    this.price = price;
                    this.delivery_time = delivery_time;
                    this.add1 = add1;
                    this.add2 = add2;
                    this.curence = curence;
                }
            }
            private answer[] answers = new answer[10];
            /// <summary>
            /// Answers provider
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public answer this[int index] {
                get
                {
                    return answers[index];
                }
                set
                {
                    answers[index] = value;
                }
            }
            protected answer answer_provider = new answer();
            /*string _id_providers, string _price, string _delivery_time, string _add1, string _add2, string _curence*/
            /// <summary>
            /// Product info
            /// </summary>
            /// <param name="_partnum">PratNumber</param>
            /// <param name="_category">Category</param>
            /// <param name="_count">Amount</param>
            /// <param name="_weight">Weight</param>
            /// <param name="_n">Answers amount</param>
            /// <param name="answers">Answers array[_n]</param>
            public Product(string _id_client,string _partnum, string _category, string _count, string _weight,int _n,answer[] answers) {
                id_client = _id_client;
                PartNum = _partnum;
                category = _category;
                count = _count;
                weight = _weight;
                n = _n;
                for (int i = 0; i < _n; i++) {
                    this.answers[i] = answers[i];  
                }

            }
        }
        /// <summary>
        /// products[a][b] - b is index of answer provider, and a is a product 
        /// </summary>
        protected static Product[] products = {
            new Product("'598'","КабельТест", "Кабель", "53", "1",2,
            new Product.answer[2]{
                new Product.answer("368", "0,01","1-2 weeks","0","0","$"),
                new Product.answer("228", "0,01","1-2 weeks","0","0","$")
            }
            ),
            /*new Product("'598'","РезисторТест", "Резистор", "132", "1")*/
        };
        //Где используется работа с продуктами настроить работу с классом!
        public static string[] deal0_PartNo = { "КабельТест","РезисторТест","КонденсаторТест","Припой тест"};
        public static string[] deal0_category = { "Кабель", "Резистор", "Конденсатор", "Припой" };
        public static string[] deal0_count = { "53", "132", "231", "440" };
        /// <summary>
        /// Deal with info about 
        /// </summary>

        private readonly By button_exit = By.XPath("//a[@href='index.php?log_out=now']");
        
        public NavigationBar_PageObj(IWebDriver webDriver) {
            _webDriver = webDriver;

            ///Check a body text
            String bodyText = _webDriver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.IndexOf("Notice") == -1, "body pf page have a notice");
            Assert.IsTrue(bodyText.IndexOf("Fatall Error") == -1, "body pf page have a fatall error");
            Assert.IsTrue(bodyText.IndexOf("Warning") == -1, "body pf page have a warning");
            Assert.IsTrue(bodyText.IndexOf("Error") == -1, "body pf page have a error");
            IWebElement[] div_elements= new IWebElement[_webDriver.FindElements(By.XPath("//div[text()]")).Count];
            _webDriver.FindElements(By.XPath("//div[text()]")).CopyTo(div_elements, 0);
            for (int i = 0; i < div_elements.Length; i++) {
                Assert.IsTrue(div_elements[i].Text.IndexOf("Notice") == -1, "div element in page have a notice");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Fatall Error") == -1, "div element in page have a fatall error");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Warning") == -1, "div element in page have a warning");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Error") == -1, "div element in page have a error");
            }
        }
        /// <summary>
        /// click on button_deal
        /// </summary>
        /// <returns>Redirect on deal_page</returns>
        public DealPage_PageObj go_to_deal() {
            _webDriver.FindElement(button_deal).Click();
            return new DealPage_PageObj(_webDriver);
        }
        /// <summary>
        /// redirect on supply page
        /// </summary>
        /// <param name="id">Id of a deal, which you create</param>
        /// <returns>Redirect on a supply page</returns>
        public SupplyPage_PageObj go_to_supply(string id) {
            _webDriver.FindElement(button_supply).Click();
            return new SupplyPage_PageObj(_webDriver, id);
        }
        //Доработать
        public void go_to_manufactorer() {
            _webDriver.FindElement(button_products).Click();
            _webDriver.FindElement(button_products_manufactorer).Click();
        }
        /// <summary>
        /// exit now user
        /// </summary>
        /// <returns>Redirect from Login_frormPageobj</returns>
        public LoginPage_PageObj exit() {
            _webDriver.FindElement(button_exit).Click();
            return new LoginPage_PageObj(_webDriver);
        }
    }
}
/*protected class Product
{
    protected string PartNum;
    protected string category;
    protected string count;
    protected string weight;
    public struct answer
    {
        string id_provider;
        string price;
        string delivery_time;
        string add1;
        string add2;
        string curence;
        public answer(string id_provider, string price, string delivery_time, string add1, string add2, string curence)
        {
            this.id_provider = id_provider;
            this.price = price;
            this.delivery_time = delivery_time;
            this.add1 = add1;
            this.add2 = add2;
            this.curence = curence;
        }
        public answer this[int index]
        {
            get
            {
                return new answer(id_provider, price, delivery_time, add1, add2, curence);
            }
            set { }
        }
    }
    protected answer answer_provider = new answer();
    *//*string _id_providers, string _price, string _delivery_time, string _add1, string _add2, string _curence*//*
    public Product(string _partnum, string _category, string _count, string _weight, answer[] _answer)
    {
        PartNum = _partnum;
        category = _category;
        count = _count;
        weight = _weight;
        for (int i = 0; i < _answer.Length; i++)
        {
            answer_provider[i] = _answer[i];
        }
    }
}
protected static Product[] products = {
            new Product("КабельТест", "Кабель", "53", "1",
                new Product.answer[1] {
                new Product.answer("368", "0,01","1-2 weeks","0","0","$")
            }
                )
        };*/