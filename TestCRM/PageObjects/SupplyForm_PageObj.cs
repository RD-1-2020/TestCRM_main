﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
namespace PageObjSpace
{

    /// <summary>
    /// form included a button supply in a deal page
    /// </summary>
    class SupplyForm_PageObj : NavigationBar_PageObj
    {
        private readonly By button_request_send = By.XPath("//input[@value='Создать заявку']");
        public SupplyForm_PageObj(IWebDriver webDriver) : base (webDriver)
        {
            
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
}
