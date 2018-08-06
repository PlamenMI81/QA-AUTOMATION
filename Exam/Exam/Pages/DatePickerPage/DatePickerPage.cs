using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Exam.Pages.DatePickerPage
{
    public partial class DatePickerPage : BasePage
    {
        public DatePickerPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToDatePickerPage()
        {
            DatepickerLink.Click();
        }
        
        public void InsertDate()
        {
            DatepickerInput.Click();
            for (int i = 1; i <=5; i++)
            {
                Prev.Click();
            }
            SelectFirstDay.Click();
        }

        public string GetInputElText()
        {
            return DatepickerInput.GetAttribute("value");
            
        }

        public void FillInput()
        {
            FormateDateTab.Click();
            InsertDate();
        }
    }
}
