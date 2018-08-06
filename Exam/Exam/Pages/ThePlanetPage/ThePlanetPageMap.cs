using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Exam.Pages.ThePlanetPage
{
    public partial class ThePlanetPage
    {
        public IWebElement BlogLink => Driver.FindElement(By.XPath("(//a[contains(.,\'Blog\')])"));

        public IWebElement SecondArticle =>
            Driver.FindElement(By.XPath("//span[@class=\'post-title\'][contains(.,\'Headless Execution of WebDriver Tests- Firefox Browser\')]"));

        public IWebElement QuickNavEl =>
            Driver.FindElement(By.XPath("//span[@class=\'tve_ct_title\'][contains(.,\'Quick Navigation\')]"));

        public IWebElement QuickNavDIV =>
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/section/article/div/div[3]/div/div[2]/div"));
    }
}
