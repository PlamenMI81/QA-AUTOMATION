namespace InteractionTests.Pages.SortablePageDefault
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    internal partial class SortablePageDefault : BasePage
    {
        public SortablePageDefault(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Url = "https://demoqa.com/sortable/";
        }

        public void ClickAndMoveElement()
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDropToOffset(FirstElement, 0, 35).Perform();
        }

        public string GetElementText()
        {
            return ElementText;
        }
    }
}