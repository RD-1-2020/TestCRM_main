﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
namespace PageObjSpace
{
    
    /// <summary>
    /// Navigation bar
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
            public string id_client;
            public string PartNum;
            public string category;
            public string count;
            public string weight;
            public int n;
            public struct answer
            {
                string id_provider;
                string price;
                string delivery_time;
                string add1;
                string add2;
                string curence;

                private static string rand_price()
                {
                    return ((new Random()).Next(101)).ToString();
                }
                private static string rand_delivery_time()
                {
                    return ((new Random()).Next(61)).ToString();
                }
                /// <summary>
                /// Construct provider answer
                /// </summary>
                /// <param name="id_provider">Id in CRM provider</param>
                /// <param name="add1">Addithional 1</param>
                /// <param name="add2">Addithional 2</param>
                /// <param name="curence">$ or rub</param>
                public answer(string id_provider, string add1, string add2, string curence)
                {
                    this.id_provider = id_provider;
                    this.price = rand_price();
                    this.delivery_time = rand_delivery_time();
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
            public answer this[int index]
            {
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
            private static string rand_count()
            {
                return (new Random()).Next(1001).ToString();
            }
            /*string _id_providers, string _price, string _delivery_time, string _add1, string _add2, string _curence*/
            /// <summary>
            /// Product info
            /// </summary>
            /// <param name="_partnum">PratNumber</param>
            /// <param name="_category">Category</param>
            /// <param name="_weight">Weight</param>
            /// <param name="_n">Answers amount</param>
            /// <param name="answers">Answers array[_n]</param>
            public Product(string _id_client, string _partnum, string _category, string _weight, int _n, answer[] answers)
            {
                id_client = _id_client;
                PartNum = _partnum;
                category = _category;
                count = rand_count();
                weight = _weight;
                n = _n;
                for (int i = 0; i < _n; i++)
                {
                    this.answers[i] = answers[i];
                }
            }
        }

        /// <summary>
        /// products[a][b] - b is index of answer provider, and a is a product 
        /// </summary>
        private static string[] client_id_s = {
                "'598'","'540'","'541'", "'542'"
                , "'543'" , "'544'" , "'545'" , "'546'" , "'547'"
                , "'548'" , "'549'" , "'550'","'551'", "'552'"
                , "'553'" , "'554'" , "'555'" , "'556'" , "'557'"
                , "'558'" , "'559'" ,"'561'", "'562'"
                , "'563'" , "'564'" , "'565'" , "'566'" , "'567'"
                , "'568'" , "'569'" , "'570'", "'571'","'572'","'573'","'574'"
        };
        public static string client_id = client_id_s[(new Random()).Next(client_id_s.Length)];
        private static string[] answers_Provider_id = { "368", "474" };
        private static int ans_amount = answers_Provider_id.Length;
        protected static Product[] products = {
            new Product(client_id,"КабельТест", "Кабель", "100",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0], "0","0","$"),
                new Product.answer(answers_Provider_id[1], "0","0","R")
            }
            ),
            new Product(client_id,"РезисторТест", "Резистор", "1",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0], "0","0","$"),
                new Product.answer(answers_Provider_id[1], "0","0","R")
            }
            ),
            new Product(client_id,"КонденсаторТест", "Конденсатор", "1",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0], "0","0","$"),
                new Product.answer(answers_Provider_id[1], "0","0","R")
            }
            ),
            new Product(client_id,"Припой тест", "Припой", "1000",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
            new Product(client_id,"BAS521", "Диод", "0,05",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
            new Product(client_id,"0 Ом+-5%", "Чип резистор", "0,01",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
            new Product(client_id,"(CCC-25G), сеч.28AWG", "Кабель", "500",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
             new Product(client_id,"(RT0603BRD07619RL)", "Реле", "23",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
             new Product(client_id,"(SMD) 0603 1.1 M0m 1% / Тайвань", "Резистор", "0,05",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
             new Product(client_id,"(LZ-35V-180 uF-d08-105C / 035SHK151M0812", "Конденсатор", "1000",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
             new Product(client_id,"LVR025K", "Предохранитель", "0.5",ans_amount,
            new Product.answer[]{
                new Product.answer(answers_Provider_id[0],"0","0","$"),
                new Product.answer(answers_Provider_id[1],"0","0","R")
            }
            ),
            /*new Product("'598'","РезисторТест", "Резистор", "132", "1")*/
        };
        private readonly By button_exit = By.XPath("//a[@href='index.php?log_out=now']");

        public NavigationBar_PageObj(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            ///Check a body text
            String bodyText = _webDriver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.IndexOf("Notice") == -1, "body page have a notice");
            Assert.IsTrue(bodyText.IndexOf("Fatal error") == -1, "body page have a fatall error");
            Assert.IsTrue(bodyText.IndexOf("Warning") == -1, "body page have a warning");
            Assert.IsTrue(bodyText.IndexOf("Error") == -1, "body page have a error");

            /*IWebElement[] div_elements= new IWebElement[_webDriver.FindElements(By.XPath("//div[text()]")).Count];
            _webDriver.FindElements(By.XPath("//div[text()]")).CopyTo(div_elements, 0);
            for (int i = 0; i < div_elements.Length; i++) {
                Assert.IsTrue(div_elements[i].Text.IndexOf("Notice") == -1, "div element in page have a notice");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Fatall Error") == -1, "div element in page have a fatall error");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Warning") == -1, "div element in page have a warning");
                Assert.IsTrue(div_elements[i].Text.IndexOf("Error") == -1, "div element in page have a error");
            }*/
        }

        protected static void check_div(IWebDriver _webDriver) {
            IWebElement[] div_inside = new IWebElement[_webDriver.FindElements(By.XPath("/html/body/div[@class='window__shadow js-window__shadow']//div")).Count];
            _webDriver.FindElements(By.XPath("/html/body/div[@class='window__shadow js-window__shadow']//div")).CopyTo(div_inside, 0);
            for (int i = 0; i < div_inside.Length; i++)
            {
                Assert.IsTrue(div_inside[i].Text.IndexOf("Notice") == -1,i.ToString() + "div have a notice");
                Assert.IsTrue(div_inside[i].Text.IndexOf("Fatal error") == -1, i.ToString() + "div have a fatall error");
                Assert.IsTrue(div_inside[i].Text.IndexOf("Warning") == -1, i.ToString() + "div have a warning");
                Assert.IsTrue(div_inside[i].Text.IndexOf("Error") == -1, i.ToString() + "div have a error");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public NewDealPage_PageObj check_all_Div()
        {
            check_div(_webDriver);
            _webDriver.FindElement(By.XPath("/html/body/div[3]/div[2]")).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
        
        
        protected string rand_string(int length)
        {
            string drink = "";
            for (int i = 0; i < length; i++)
            {
                drink += (char)new Random().Next(32, 127);
            }
            return drink;
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
