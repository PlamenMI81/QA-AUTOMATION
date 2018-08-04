using OpenQA.Selenium;
using System.Collections.Generic;

namespace ExamPrep.Pages.HomePage
{
    internal partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "http://flagpedia.net/index";
        }

        public List<string> GetAllCountryLinks()
        {
            var hrefList = new List<string>();
            foreach (var td in TdsElements)
            {
                var a = td.FindElement(By.TagName("a"));
                var href = a.GetAttribute("href");
                hrefList.Add(href);
            }
            return hrefList;
        }
    }
}