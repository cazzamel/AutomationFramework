using AutomationFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAEmployeeTest.Pages
{
    class HomePage : BasePage
    {

        IWebElement EmployeeListButton => _driver.FindElementByLinkText("Employee List");
        IWebElement LoginLink => _driver.FindElementById("loginLink");
        IWebElement LoginName => _driver.FindElementByXPath("//a[@title='Manage']");

        public LoginPage ClickLogin()
        {
            LoginLink.Click();
            return GetInstance<LoginPage>();
        }

        public EmployeePage ClickEmployeeListLink()
        {
            EmployeeListButton.Click();
            return GetInstance<EmployeePage>();
        }

        public string LoggedInName()
        {
            return LoginName.Text;
        }
    }
}
