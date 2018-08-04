using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ExamPrep.Pages.HomePage
{
    using OpenQA.Selenium;
    internal partial class HomePage
    {
        private IList<IWebElement> TdsElements => Driver
            .FindElement(By.XPath("//article[@id=\'content\']"))
            .FindElements(By.ClassName("td-country"));
    }
}
