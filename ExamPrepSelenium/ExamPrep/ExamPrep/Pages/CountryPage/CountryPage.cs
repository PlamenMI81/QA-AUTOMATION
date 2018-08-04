using OpenQA.Selenium;

namespace ExamPrep.Pages.CountryPage
{
    internal partial class CountryPage : BasePage
    {
        public CountryPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCountryName()
        {
            return Name;
        }

        public string GetCountryCapital()
        {
            return Capital;
        }

        public string GetCountryCode()
        {
            var startIdx = Code.IndexOf('(');
            return Code.Substring(startIdx + 1, 3);
        }

        public void ScrollToBottom()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }

        public void TakeScreenshot(string name, string capital, string code)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile($"../../../Screenshots/{name}-{capital}-{code}.png",
                ScreenshotImageFormat.Png);
        }
    }
}