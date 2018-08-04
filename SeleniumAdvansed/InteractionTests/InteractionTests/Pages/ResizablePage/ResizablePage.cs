using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace InteractionTests.Pages.ResizablePage
{
    internal partial class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/resizable/";
        }

        public void ResizeObject()
        {
            Actions action = new Actions(this.Driver);
            action.MoveToElement(arrow).ClickAndHold().MoveByOffset(50, 50).Release().Perform();
        }

        public System.Drawing.Size GetSize()
        {
            return elementDiv.Size;
        }
    }
}