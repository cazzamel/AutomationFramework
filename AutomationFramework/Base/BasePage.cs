using OpenQA.Selenium.Remote;

namespace AutomationFramework.Base
{
    public abstract class BasePage : Base
    {
        protected RemoteWebDriver _driver;
        protected BasePage() => _driver = (RemoteWebDriver)DriverContext.Driver;

    }
}