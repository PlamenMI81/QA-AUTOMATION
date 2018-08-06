using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace Exam.Pages.TooltipPage
{
    public partial class TooltipPage : BasePage
    {
        public TooltipPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToTooltipPage()
        {
            TooltipLink.Click();
        }

        public void ClickInput()
        {
            InputEl.Click();
        }

        public string GetTooltipText()
        {
            //return InputEl.GetAttribute("title");
            Thread.Sleep(1000);
            return TooltipDIV.Text;
        }

        public bool isTooltipVisible()
        {
            //return GetTooltipText().Length == 0;
            return TooltipDIV.Displayed;
        }

    }
}
