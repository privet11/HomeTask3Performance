using System;
using System.Collections.Generic;
using HomeTask3.Assembly;
using HomeTask3.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeTask3
{
    
    [TestClass]
    public class Tests:PagesGetter
    {
        private static string baseURL = "http://demo.nopcommerce.com/";
        static List<PageMetrics> MetricsList = new List<PageMetrics>();

        [TestMethod]
        public void Test1_OpenHomePage()
        {
            Driver.WebDriver.Navigate().GoToUrl(baseURL);
            Assert.IsTrue(GetPages<HomePage>().IsPageLoad());
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            NavigationTiming timing = new NavigationTiming(js);
            MetricsList.Add(timing.GetMetrics("Home Page"));
        }

        [TestMethod]
        public void Test2_OpenComputersPage()
        {
            GetPages<HomePage>().OpenComputersPage();
            Assert.IsTrue(GetPages<ComputersPage>().IsPageLoad());
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            NavigationTiming timing = new NavigationTiming(js);
            MetricsList.Add(timing.GetMetrics("Computers Page"));
        }

        [TestMethod]
        public void Test3_OpenDesktopsPage()
        {
            GetPages<ComputersPage>().OpenDesktopsPage();
            Assert.IsTrue(GetPages<DesktopsPage>().IsPageLoad());
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            NavigationTiming timing = new NavigationTiming(js);
            MetricsList.Add(timing.GetMetrics("Desktops Page"));

        }

        [TestMethod]
        public void Test4_OpenProductPage()
        {
            GetPages<DesktopsPage>().OpenProductPage();
            Assert.IsTrue(GetPages<ProductPage>().IsPageLoad());
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            NavigationTiming timing = new NavigationTiming(js);
            MetricsList.Add(timing.GetMetrics("Product Page"));
            timing.WriteMetricsToJsonFileAsync(MetricsList);
        }
    }
}
