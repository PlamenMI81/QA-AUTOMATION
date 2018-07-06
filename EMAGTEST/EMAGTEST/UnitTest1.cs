using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EMAGTEST
{
    [TestClass]
    public class Tests
    {

        IWebDriver driver = new ChromeDriver();
        [Test]
        public void myFirstTest()
        {
            driver.Navigate().GoToUrl("https://www.emag.bg");
            var elementSearch = driver.FindElement(By.Id("searchboxTrigger"));
            string toster = "Тостер Star-Light TS-800W";
            elementSearch.SendKeys(toster);
            elementSearch.Submit();
            string tosterFull = "Тостер Star-Light TS-800W, 800 W, 2 филии, Регулируема степен на изпичане, Функция размразяване, Инокс";
            driver.FindElement(By.LinkText(tosterFull)).Click();
            driver.FindElement(By.CssSelector(".em.em-cart_fill.gtm_680klw")).Submit();
            var actual = driver.FindElement(By.XPath($"//a[contains(@title, '{toster}')]"));
            NUnit.Framework.Assert.AreEqual(tosterFull, actual.Text);
            driver.Close();
            driver.Quit();
        }

    }
}
