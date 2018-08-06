using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Exam.Pages
{
    public class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebDriver Driver { get; set; }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/";
            Driver.Manage().Window.Maximize();
        }

        public void NavigateToThePlanet()
        {
            this.Driver.Url = "https://www.automatetheplanet.com/";
            Driver.Manage().Window.Maximize();
        }
    }
}
