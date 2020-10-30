using HomeTask3.Assembly;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3.Pages
{
    public class DesktopsPage: BasePage
    {
        private readonly IWebElement productButt = webDriver.FindElement(By.XPath("//div[contains(@class,'picture')]/a[contains(@href,'build')]"));

        public void OpenProductPage()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
            executor.ExecuteScript("arguments[0].click();", productButt);
        }

        public bool IsPageLoad()
        {
            if (productButt.Displayed)
            {
                return true;
            }
            return false;
        }
    }
}
