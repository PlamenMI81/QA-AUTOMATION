using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Exam.Pages.TooltipPage
{
    public partial class TooltipPage
    {
        public IWebElement InputEl =>
            Driver.FindElement(By.Id("age"));

        public IWebElement TooltipLink =>
            Driver.FindElement(By.XPath("//a[contains(.,\'Tooltip\')]"));

        public IWebElement TooltipDIV => Driver.FindElement(By.XPath("//div[@class=\'ui-tooltip-content\']"));
    }
}
