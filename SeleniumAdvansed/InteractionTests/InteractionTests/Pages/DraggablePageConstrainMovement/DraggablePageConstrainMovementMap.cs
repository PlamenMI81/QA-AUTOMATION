using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InteractionTests.Pages.DraggablePageConstrainMovement
{
    internal partial class DraggablePageConstrainMovement
    {
        private IWebElement SecondTab => this.Driver.FindElement(By.Id("ui-id-2"));
        private IWebElement DraggableObjectSecondTab => this.Driver.FindElement(By.Id("draggabl"));
    }
}
