namespace InteractionTests.Pages.SortablePageDefault
{
    using OpenQA.Selenium;
    using System.Linq;

    internal partial class SortablePageDefault
    {
        private IWebElement FirstElement => this.Driver.FindElement(By.XPath("(//li[contains(.,\'Item 1\')])[1]"));

        private string ElementText => this.Driver
            .FindElement(By.Id("sortable"))
            .FindElements(By.TagName("li")).ToList()[1].Text;
    }
}