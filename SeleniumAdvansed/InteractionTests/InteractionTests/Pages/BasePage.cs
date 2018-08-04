namespace InteractionTests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    internal abstract class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebDriver Driver { get; set; }
    }
}