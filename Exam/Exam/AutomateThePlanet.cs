using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Exam.Pages.ThePlanetPage;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Exam
{
    [TestFixture]
    class AutomateThePlanet
    {
        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        public IWebDriver Driver { get; set; }

        [Test]
        public void ThePlanet()
        {
            var thePlanet = new ThePlanetPage(Driver);
            thePlanet.NavigateToThePlanet();
            thePlanet.ClickBlogLink();
            thePlanet.Scroll();
            thePlanet.OpenSecondArticle();
            thePlanet.ScrolltoQuickNav();
            var list = thePlanet.GetAllLinks();
            foreach (var aElement in list)
            {
                aElement.Click();
                Thread.Sleep(1000);
                var linkName = aElement.Text;
                var el = Driver.
                    FindElement(By.XPath($"//h2[contains(.,\'{linkName}\')]|//h3[contains(.,\'{linkName}\')]"));
                linkName.Should().Be(el.Text);
                el.TagName.Should().BeOneOf("h2", "h3");
                thePlanet.Back();
            }
        }
    }
}
