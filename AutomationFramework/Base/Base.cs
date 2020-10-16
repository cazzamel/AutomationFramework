using AutomationFramework.Config;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutomationFramework.Base
{
    public class Base
    {

        public BasePage CurrentPage { get; set; }

        //private IWebDriver _driver { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                //_driver = (RemoteWebDriver)DriverContext.Driver
            };

            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

        //public virtual void NavigateSite()
        //{
        //    DriverContext.Browser.GoToUrl(Settings.url);
        //    LogHelpers.WriteMessage("Navigated to Page");
        //}
    }
}
