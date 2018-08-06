using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Exam.Pages.TooltipPage;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Exam
{
    [TestFixture]
    class TooltipTests
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
        public void Tooltip()
        {
            var inputEl = new TooltipPage(Driver);
            inputEl.NavigateTo();
            inputEl.GoToTooltipPage();
            inputEl.ClickInput();

            string title=inputEl.GetTooltipText();
            bool isVisibl = inputEl.isTooltipVisible();

            title.Should().Be("We ask for your age only for statistical purposes.");
            isVisibl.Should().BeTrue();
        }
    }
}
