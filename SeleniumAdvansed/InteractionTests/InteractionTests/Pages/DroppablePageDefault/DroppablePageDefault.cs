using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.DroppablePageDefault
{
    internal partial class DroppablePageDefault : BasePage
    {
        public DroppablePageDefault(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/droppable/";
        }

        public void DragObjectAndDropInTarget()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDrop(DraggableObject, DropableObject);
            action.Perform();
        }

        public string GetTargetObjectTextNode()
        {
            return DropableText;
        }
    }
}
