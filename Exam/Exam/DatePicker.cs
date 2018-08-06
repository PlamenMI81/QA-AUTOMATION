using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Exam.Pages.DatePickerPage;
using Exam.Pages.TooltipPage;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Exam
{
    [TestFixture]
    class DatePicker
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
                var testName = TestContext.CurrentContext.Test.Name;
                testName=testName.Replace(",", "");
                testName=testName.Replace("(", "");
                testName=testName.Replace(")", "");
                testName=testName.Replace("\"", "");
                screenshot.SaveAsFile("../../../Screenshots/" + testName + ".png",ScreenshotImageFormat.Png);
            }
            Driver.Quit();
        }

        public IWebDriver Driver { get; set; }

        [TestCase(0, "March 1, 2017")]
        [TestCase(1, "2018-03-01")]
        [TestCase(2, "1 Mar, 18")]
        [TestCase(3, "1 March, 18")]
        [TestCase(4, "Thursday, 1 March, 2018")]
        [TestCase(5, "day 1 of March in the year 2018")]
        public void CheckDefaultFormat(int index, string date)
        {
            var datePicker = new DatePickerPage(Driver);

            datePicker.NavigateTo();
            datePicker.GoToDatePickerPage();

            datePicker.FillInput();
            var text = datePicker.GetInputElText();
            var selectElement = new SelectElement(datePicker.SelectOption);
            selectElement.SelectByIndex(index);
            text = datePicker.GetInputElText();
            text.Should().Be(date);
        }

        //[Test]
        //public void CheckISOFormat()
        //{
        //    var datePicker = new DatePickerPage(Driver);

        //    datePicker.NavigateTo();
        //    datePicker.GoToDatePickerPage();

        //    datePicker.FillInput();
        //    var text = datePicker.GetInputElText();
        //    var selectElement = new SelectElement(datePicker.SelectOption);
        //    selectElement.SelectByIndex(1);
        //    text = datePicker.GetInputElText();
        //    text.Should().Be("2018-03-01");
        //}

        //[Test]
        //public void CheckShortFormat()
        //{
        //    var datePicker = new DatePickerPage(Driver);

        //    datePicker.NavigateTo();
        //    datePicker.GoToDatePickerPage();

        //    datePicker.FillInput();
        //    var text = datePicker.GetInputElText();
        //    var selectElement = new SelectElement(datePicker.SelectOption);
        //    selectElement.SelectByIndex(2);
        //    text = datePicker.GetInputElText();
        //    text.Should().Be("1 Mar, 18");
        //}

        //[Test]
        //public void CheckMediumFormat()
        //{
        //    var datePicker = new DatePickerPage(Driver);

        //    datePicker.NavigateTo();
        //    datePicker.GoToDatePickerPage();

        //    datePicker.FillInput();
        //    var text = datePicker.GetInputElText();
        //    var selectElement = new SelectElement(datePicker.SelectOption);
        //    selectElement.SelectByIndex(3);
        //    text = datePicker.GetInputElText();
        //    text.Should().Be("1 March, 18");
        //}

        //[Test]
        //public void CheckFullFormat()
        //{
        //    var datePicker = new DatePickerPage(Driver);

        //    datePicker.NavigateTo();
        //    datePicker.GoToDatePickerPage();

        //    datePicker.FillInput();
        //    var text = datePicker.GetInputElText();
        //    var selectElement = new SelectElement(datePicker.SelectOption);
        //    selectElement.SelectByIndex(4);
        //    text = datePicker.GetInputElText();
        //    text.Should().Be("Thursday, 1 March, 2018");
        //}

        //[Test]
        //public void CheckWithTextFormat()
        //{
        //    var datePicker = new DatePickerPage(Driver);

        //    datePicker.NavigateTo();
        //    datePicker.GoToDatePickerPage();

        //    datePicker.FillInput();
        //    var text = datePicker.GetInputElText();
        //    var selectElement = new SelectElement(datePicker.SelectOption);
        //    selectElement.SelectByIndex(5);
        //    text = datePicker.GetInputElText();
        //    text.Should().Be("day 1 of March in the year 2018");
        //}
    }
}
