using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Base
{
    public class Browser : Base
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }

        //public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        //{
        //    switch (browserType)
        //    {
        //        case BrowserType.Chrome:
        //            DriverContext.Driver = new ChromeDriver();
        //            //DriverContext.Browser = new Browser(DriverContext.Driver);
        //            break;
        //        case BrowserType.Edge:
        //            DriverContext.Driver = new EdgeDriver();
        //            //DriverContext.Browser = new Browser(DriverContext.Driver);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        public void Quit()
        {
            DriverContext.Driver.Quit();
        }
    }

    public enum BrowserType
    {
        Chrome,
        Edge
    }
}
