using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InteractionTests.Pages.SelectablePageDefault
{
    internal partial class SelectablePageDefault
    {
        private IWebElement FirstLi => this.Driver.FindElement(By.XPath("(//li[contains(.,\'Item 1\')])[1]"));
    }
}
