using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EMAGTEST
{
    [TestClass]
    public class Tests
    {


        [TestMethod]
        public void GetItemInBasket()
        {
            
            var article = "Тостер Star-Light TS - 800W";
            var driver = new ChromeDriver();
            driver.Url = "https://www.emag.bg/";
            driver.Manage().Window.Maximize();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.FindElement(By.XPath("/html/body/header/div/div[1]/a")).Click();

            driver.FindElement(By.XPath("//*[@id=\"searchboxTrigger\"]")).SendKeys(article + Keys.Enter);

            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/section[1]/div/div[3]/div[2]/div[3]/div[1]/div/div/div[2]/div/h2/a")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/section[1]/div/div[2]/div[2]/div/div/div[2]/form/div[3]/button[1]")).Click();

            var closeModal = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[10]/div/div/div[1]/button[1]")));
            closeModal.Click();

            driver.Navigate().GoToUrl("https://www.emag.bg/cart/products?ref=cart");
            var cartName = driver.FindElementByXPath("//*[@id=\"cartProductsPage\"]/h1");
            var articleName = driver.FindElementByXPath("//*[@id=\"vendorsContainer\"]/div/div[1]/div/div[2]/div[1]/div[1]/a");
            StringAssert.Contains(articleName.Text,"Тостер Star-Light TS-800W");
            Assert.AreEqual("Количка за пазаруване", cartName.Text);
            driver.Quit();
        }
    }
}
