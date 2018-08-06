using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exam.Pages.DatePickerPage
{
    public partial class DatePickerPage
    {
        public IWebElement DatepickerLink => Driver.FindElement(By.XPath("//a[contains(.,\'Datepicker\')]"));
        public IWebElement FormateDateTab => Driver.FindElement(By.XPath("//a[contains(.,\'Format date\')]"));
        public IWebElement DatepickerInput => Driver.FindElement(By.XPath("//input[@id=\'datepicker4\']"));
        public IWebElement Prev => Driver.FindElement(By.XPath("//a[@data-handler=\'prev\']"));
        public IWebElement SelectFirstDay =>
            Driver.FindElement(By.XPath("/html/body/div[5]/table/tbody/tr[1]/td[4]/a"));
        public IWebElement SelectOption =>
            Driver.FindElement(By.Id("format"));

    }
}
