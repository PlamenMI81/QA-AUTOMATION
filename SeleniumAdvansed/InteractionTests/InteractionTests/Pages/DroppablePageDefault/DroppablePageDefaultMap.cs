using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InteractionTests.Pages.DroppablePageDefault
{
    internal partial class DroppablePageDefault
    {
        private IWebElement DraggableObject => this.Driver.FindElement(By.Id("draggableview"));
        private IWebElement DropableObject => this.Driver.FindElement(By.Id("droppableview"));
        private string DropableText => this.Driver.FindElement(By.XPath("//p[contains(.,\'Dropped!\')]")).Text;
        
    }
}
