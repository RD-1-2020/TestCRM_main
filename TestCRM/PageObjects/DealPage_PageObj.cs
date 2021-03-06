﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
namespace PageObjSpace
{
     class DealPage_PageObj : NavigationBar_PageObj
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
}
