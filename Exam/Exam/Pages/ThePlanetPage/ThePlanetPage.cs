using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Exam.Pages.ThePlanetPage
{
    public partial class ThePlanetPage : BasePage
    {
        public ThePlanetPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickBlogLink()
        {
            BlogLink.Click();
        }

        public void Scroll()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,900)");
        }

        public void ScrolltoQuickNav()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", QuickNavEl);
            js.ExecuteScript("window.scrollBy(0,-150)");
        }

        public void OpenSecondArticle()
        {
            SecondArticle.Click();
        }

        public IList<IWebElement> GetAllLinks()
        {
           return QuickNavDIV.FindElements(By.TagName("a"));
        }

        public void Back()
        {
            Driver.Navigate().Back();
        }
    }
}
