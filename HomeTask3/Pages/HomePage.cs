using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3.Pages
{
    public class HomePage: BasePage
    {
        private readonly IWebElement computersButt = webDriver.FindElement(By.XPath("//a[@href='/computers']"));

        public void OpenComputersPage() => computersButt.Click();
        public bool IsPageLoad()
        {
            if (computersButt.Displayed)
            {
                return true;
            }
            return false;
        }
    }
}
