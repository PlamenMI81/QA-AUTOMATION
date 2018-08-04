using OpenQA.Selenium;

namespace InteractionTests.Pages.ResizablePage
{
    internal partial class ResizablePage
    {
        private IWebElement arrow => this.Driver.FindElement(By.XPath("(//div[@style=\'z-index: 90;\'])[3]"));
        private IWebElement elementDiv => this.Driver.FindElement(By.Id("resizable"));
    }
}