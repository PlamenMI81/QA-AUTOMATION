using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.SelectablePageDefault
{
    internal partial class SelectablePageDefault : BasePage
    {
        public SelectablePageDefault(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/selectable/";
        }

        public void SelectFirstLI()
        {
            Actions action = new Actions(this.Driver);
            action.MoveToElement(FirstLi).Click().Perform();
        }

        public bool ContainSelectableClass()
        {
            var classes=FirstLi.GetAttribute("class").Split(" ");
            foreach (string c in classes)
            {
                if (c.Equals("ui-selected"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
