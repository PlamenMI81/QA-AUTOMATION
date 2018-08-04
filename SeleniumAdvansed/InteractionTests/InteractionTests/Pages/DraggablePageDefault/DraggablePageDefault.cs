using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.DraggablePageDefault
{
    internal partial class DraggablePageDefault : BasePage
    {
        public DraggablePageDefault(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/draggable/";
        }

        public void DragObjectByPixels()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDropToOffset(this.DraggableObject, 50, 250);
            action.Perform();
        }

        public System.Drawing.Point ObjectCurrentPosition()
        {
            return this.DraggableObject.Location;
        }
    }
}