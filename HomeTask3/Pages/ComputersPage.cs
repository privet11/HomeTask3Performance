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
    public class ComputersPage: BasePage
    {
        private readonly IWebElement desktopsButt = webDriver.FindElement(By.XPath("//h2[contains(@class,'title')]/a[@href='/desktops' and not(@disabled)]"));


        public void OpenDesktopsPage()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
            executor.ExecuteScript("arguments[0].click();", desktopsButt);
        }

        public bool IsPageLoad()
        {
            if (desktopsButt.Displayed)
            {
                return true;
            }
            return false;
        }
    }
}
