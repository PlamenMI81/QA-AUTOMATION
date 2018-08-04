using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.DraggablePageConstrainMovement
{
    internal partial class DraggablePageConstrainMovement : BasePage
    {
        public DraggablePageConstrainMovement(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/draggable/";
        }

        public void DragObjectVertically()
        {
            Actions action = new Actions(this.Driver);
            SecondTab.Click();
            action.DragAndDropToOffset(this.DraggableObjectSecondTab, 50, 50);
            action.Perform();
        }

        public void OpenSecondTab()
        {
            SecondTab.Click();
        }

        public System.Drawing.Point ObjectCurrentPosition()
        {
            return this.DraggableObjectSecondTab.Location;
        }
    }
}
