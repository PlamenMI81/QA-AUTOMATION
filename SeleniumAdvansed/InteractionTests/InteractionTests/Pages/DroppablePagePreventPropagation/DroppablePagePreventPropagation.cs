using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.DroppablePagePreventPropagation
{
    internal partial class DroppablePagePreventPropagation : BasePage
    {
        public DroppablePagePreventPropagation(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/droppable/";
        }

        public void OpenThirdTab()
        {
            ThirdTab.Click();
        }

        public void DragObjectAndDropInInnerTarget()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDrop(DraggableObject, DropableObject);
            action.Perform();
        }

        public string GetInnerTargetObjectTextNode()
        {
            return InnerDropableText;
        }

        public string GetOuterTargetObjectTextNode()
        {
            return OuterDropableText;
        }
    }
}
