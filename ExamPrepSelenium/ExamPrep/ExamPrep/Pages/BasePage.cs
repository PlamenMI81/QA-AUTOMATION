namespace ExamPrep.Pages
{
    using OpenQA.Selenium;
    internal abstract class BasePage
    {
        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebDriver Driver { get; set; }
    }
}
