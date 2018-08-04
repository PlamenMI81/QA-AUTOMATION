using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InteractionTests.Pages.DraggablePageDefault
{
    internal partial class DraggablePageDefault
    {
        private IWebElement DraggableObject => this.Driver.FindElement(By.Id("draggable"));        
    }
}
