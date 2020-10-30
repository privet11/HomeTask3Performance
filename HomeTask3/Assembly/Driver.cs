using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace HomeTask3.Assembly
{
    public class Driver
    {
        private static IWebDriver webDriver = null;
        private static string baseURL = "http://demo.nopcommerce.com/";

        public static IWebDriver WebDriver
        {
            get
            {
                if (webDriver == null)
                {
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    //webDriver.Navigate().GoToUrl(baseURL);
                }
                return webDriver;
            }
            set
            {
                webDriver = value;
            }
        }

        public static void ExplicitWait(int sec, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(sec));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
