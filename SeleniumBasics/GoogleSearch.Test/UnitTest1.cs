using System;
using System.IO;
using System.Reflection;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearch.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver=new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.bg/");
            driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium"+Keys.Enter);
            driver.FindElement(By.PartialLinkText("Selenium - Web Browser Automation")).Click();
            Assert.Equal("Selenium - Web Browser Automation",driver.Title);
            driver.Close();
            driver.Quit();
        }
    }
}
