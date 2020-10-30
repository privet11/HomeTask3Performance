using HomeTask3.Assembly;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3.Pages
{
    class ProductPage : BasePage
    {
        private readonly IWebElement addToCartButt = webDriver.FindElement(By.XPath("//input[@id='add-to-cart-button-1']"));

        public bool IsPageLoad()
        {
            if (addToCartButt.Displayed)
            {
                return true;
            }
            return false;
        }
    }
}
