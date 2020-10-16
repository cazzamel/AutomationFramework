using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace EAEmployeeTest.Pages
{
    class EmployeePage : BasePage
    {
        IWebElement Search => _driver.FindElementByName("searchTerm");
        IWebElement CreateNew => _driver.FindElementByLinkText("Create New");
        IWebElement tblEmployeeList => _driver.FindElementByClassName("table");

        public CreateEmployeePage ClickCreateNew()
        {
            CreateNew.Click();
            return GetInstance<CreateEmployeePage>();
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }
    }
}
