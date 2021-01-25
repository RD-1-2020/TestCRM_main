using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using OpenQA.Selenium;
using NUnit.Framework;

namespace PageObjSpace
{
    /// <summary>
    /// Login page
    /// </summary>
    public class LoginPage_PageObj
    {
        /// <summary>
        /// User Data for Test
        /// </summary>
        public struct data
        {
            public string email;
            public string pass;
            /// <summary>
            /// Construct struct user data
            /// </summary>
            /// <param name="_email">Email user</param>
            /// <param name="_pass">Password user</param>
            public data(string _email, string _pass)
            {
                email = _email;
                pass = _pass;
            }
        }
        /// <summary>
        /// Users data array
        /// </summary>
        public static data[] arr_data ={
            new data("testing@sibelcom54.com","Test2020!"),
            new data("testing_2@sibelcom54.com","Test2020!"),
            //Кабаков Станислав, менеджер по продажам
            new data("sk@sibelcom54.com","2206SK"),
            //Глушкова Софья, снабжение
            new data("gs@sibelcom54.com","Gs3007"), };
        /// <summary>
        /// Length Data array(Login_FormPageObj/@class=log)
        /// </summary>
        public int Length;

        private readonly By button_sign = By.XPath("//input[@name='submit']");

        private readonly By input_email = By.XPath("//input[@name='email']");
        private readonly By input_pass = By.XPath("//input[@type='password']");
        private IWebDriver _webDriver;
        public LoginPage_PageObj(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Length = arr_data.Length;
        }
        /// <summary>
        /// Sign in 
        /// </summary>
        /// <param name="num">Number of data(Logs.cs)</param>
        /// <returns></returns>
        public NavigationBar_PageObj Sign_in(int num)
        {
            _webDriver.FindElement(input_email).SendKeys(arr_data[num].email);
            _webDriver.FindElement(input_pass).SendKeys(arr_data[num].pass);
            _webDriver.FindElement(button_sign).Click();
            return new CalendarPage_PageObj(_webDriver);
        }
    }

    /// <summary>
    /// Navigation bar
    /// </summary>
    public class NavigationBar_PageObj
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
                Assert.IsTrue(bodyText.IndexOf("Fatall Error") == -1, "body page have a fatall error");
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
    /// <summary>
    /// Calendar page
    /// </summary>
    public class CalendarPage_PageObj : NavigationBar_PageObj
    {
        public CalendarPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
    }
    /// <summary>
    /// add product with list in deal form
    /// </summary>
    public class ProductListForm_PageObj : NavigationBar_PageObj
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
            for (int i = new Random().Next(products.Length * 2 / 3,products.Length); i < products.Length; i++)
            {
                _webDriver.FindElement(textarea_partno).SendKeys(products[i].PartNum + "\n");
                _webDriver.FindElement(textarea_count).SendKeys(products[i].count + "\n");
                _webDriver.FindElement(textarea_category).SendKeys(products[i].category + "\n");
            }
            _webDriver.FindElement(button_add).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
    }
    /// <summary>
    /// Deal page
    /// </summary>
    public class NewDealPage_PageObj : NavigationBar_PageObj
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
    /// <summary>
    /// form included a button supply in a deal page
    /// </summary>
    public class SupplyForm_PageObj
    {
        private IWebDriver _webDriver;
        private readonly By button_request_send = By.XPath("//input[@value='Создать заявку']");
        public SupplyForm_PageObj(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        /// <summary>
        /// Post fill(no important) form click on a button "add"
        /// </summary>
        /// <returns></returns>
        public NewDealPage_PageObj send_request()
        {
            _webDriver.FindElement(button_request_send).Click();
            return new NewDealPage_PageObj(_webDriver);
        }
    }
    /// <summary>
    /// Button add new deal include this form
    /// </summary>
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
    /// <summary>
    /// One deal page
    /// </summary>
    public class DealPage_PageObj : NavigationBar_PageObj
    {
        private readonly By button_newdeal = By.XPath("//a[text()=' Новая сделка']");

        public DealPage_PageObj(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Do new deal
        /// </summary>
        /// <returns>redirect newdealform</returns>
        public NewDealForm_PageObj New_Deal()
        {
            _webDriver.FindElement(button_newdeal).Click();
            return new NewDealForm_PageObj(_webDriver);
        }
    }
    /// <summary>
    /// page supply included from a supply button in navigation bar
    /// </summary>
    public class SupplyPage_PageObj : NavigationBar_PageObj
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
        public SupplyDealPage_PageObj open_supply_deal()
        {
            _webDriver.FindElement(By.XPath("//a[text()='" + deal_id + "_s" + "']")).Click();
            return new SupplyDealPage_PageObj(_webDriver, deal_id);
        }


    }
    /// <summary>
    /// supply page of deal 
    /// </summary>
    public class SupplyDealPage_PageObj : NavigationBar_PageObj
    {
        private readonly By button_take_in_work = By.XPath("//a[text()='Взять в работу']");

        private readonly By button_request_provider = By.XPath("//span[text()='Отправить заявку поставщику']");
        //Реализовать!!!
        /* public ProviderRequestForm_PageObj request_provider() { 

         }*/
        private string deal_id;
        public SupplyDealPage_PageObj(IWebDriver webDriver, string id) : base(webDriver)
        {
            deal_id = id;
        }
        public SupplyDealPage_PageObj take_in_work()
        {
            _webDriver.FindElement(button_take_in_work).Click();
            return new SupplyDealPage_PageObj(_webDriver, deal_id);
        }
    }
}
   
