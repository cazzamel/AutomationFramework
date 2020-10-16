using AutomationFramework.Config;
using AutomationFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Base
{
    public abstract class BaseStep : Base
    {

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.url);
            LogHelpers.WriteMessage("Navigated to Page");
        }
    }
}
