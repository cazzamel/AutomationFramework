using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {

        //private readonly RemoteWebDriver _driver;
        //public LoginPage(IWebDriver driver) => _driver = (RemoteWebDriver)driver;

        IWebElement UserName => _driver.FindElementById("UserName");
        IWebElement Password => _driver.FindElementById("Password");
        IWebElement LoginButton => _driver.FindElementByCssSelector("#loginForm > form > div:nth-child(5) > div > input");
        
        //Menu Buttons
        //IWebElement EmployeeListButton => _driver.FindElementByLinkText("Employee List");
        //IWebElement LoginLink => _driver.FindElementById("loginLink");

        public void EnterLoginDetails(string username, string password)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
        }

        public HomePage ClickLogin()
        {
            LoginButton.Submit();
            return GetInstance<HomePage>();
        }
        //public HomePage ClickLoginLink()
        //{
        //    LoginLink.Click();
        //    return GetInstance<HomePage>();
        //}

        //public EmployeePage ClickEmployeeListLink()
        //{
        //    EmployeeListButton.Click();
        //    return GetInstance<EmployeePage>();
        //}

    }
}
