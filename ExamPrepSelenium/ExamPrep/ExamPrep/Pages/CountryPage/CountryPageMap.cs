using OpenQA.Selenium;

namespace ExamPrep.Pages.CountryPage
{
    internal partial class CountryPage
    {
        private string Name =>
            Driver.FindElement(By.XPath(
                "//dd[preceding-sibling::dt[contains(text(),\'Country\')]]")).Text;

        private string Capital => Driver.FindElement(By.XPath(
            "//dd[preceding-sibling::dt[contains(text(),\'Capital city\')]]")).Text;

        private string Code => Driver.FindElement(By.XPath(
            "//dd[preceding-sibling::dt[contains(text(),\'Code\')]]")).Text;
    }
}