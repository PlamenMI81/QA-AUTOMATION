using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InteractionTests.Pages.DroppablePagePreventPropagation
{
    internal partial class DroppablePagePreventPropagation
    {
        private IWebElement ThirdTab => this.Driver.FindElement(By.Id("ui-id-3"));
        private IWebElement DraggableObject => this.Driver.FindElement(By.Id("draggableprop"));
        private IWebElement DropableObject => this.Driver.FindElement(By.Id("droppable2-inner"));
        private string InnerDropableText => this.Driver.FindElement(By.XPath("//p[contains(.,\'Dropped!\')]")).Text;
        private string OuterDropableText => this.Driver.FindElement(By.XPath("(//p[contains(.,\'Outer droppable\')])[2]")).Text;


    }
}
