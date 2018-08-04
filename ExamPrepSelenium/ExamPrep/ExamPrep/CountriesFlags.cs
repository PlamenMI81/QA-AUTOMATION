using ExamPrep.Pages.CountryPage;
using ExamPrep.Pages.HomePage;
using System.Threading;

namespace ExamPrep
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    internal class CountriesFlags
    {
        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile("../../../Screenshots/" + TestContext.CurrentContext.Test.Name + ".png",
                    ScreenshotImageFormat.Png);
            }
            Driver.Close();
            Driver.Quit();
        }

        public IWebDriver Driver { get; set; }

        [Test]
        public void GetCountriesData()
        {
            var homePage = new HomePage(Driver);
            var countryPage = new CountryPage(Driver);
            homePage.NavigateTo();
            var countryLinks = homePage.GetAllCountryLinks();
            foreach (var country in countryLinks)
            {
                Driver.Url = country;
                var name = countryPage.GetCountryName();
                var capital = countryPage.GetCountryCapital();
                var code = countryPage.GetCountryCode();
                countryPage.ScrollToBottom();
                Thread.Sleep(1000);
                countryPage.TakeScreenshot(name, capital, code);
            }
        }
    }
}