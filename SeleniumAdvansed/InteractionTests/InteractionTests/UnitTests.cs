namespace InteractionTests
{
    using FluentAssertions;
    using InteractionTests.Pages.DraggablePageConstrainMovement;
    using InteractionTests.Pages.DraggablePageDefault;
    using InteractionTests.Pages.DroppablePageDefault;
    using InteractionTests.Pages.DroppablePagePreventPropagation;
    using InteractionTests.Pages.ResizablePage;
    using InteractionTests.Pages.SelectablePageDefault;
    using InteractionTests.Pages.SortablePageDefault;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class UnitTests
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
            Driver.Quit();
        }

        public IWebDriver Driver { get; set; }

        [Test]
        public void DragElementAndDropInTarget()
        {
            var droppablePageDefault = new DroppablePageDefault(Driver);
            droppablePageDefault.NavigateTo();
            droppablePageDefault.DragObjectAndDropInTarget();
            var text = droppablePageDefault.GetTargetObjectTextNode();
            //Assert.AreEqual("Dropped!", text);
            "Dropped!".Should().Be(text);
        }

        [Test]
        public void DragElementAndDropInTargetWithPreventPropagation()
        {
            var droppablePagePreventPropagation = new DroppablePagePreventPropagation(Driver);
            droppablePagePreventPropagation.NavigateTo();
            droppablePagePreventPropagation.OpenThirdTab();
            droppablePagePreventPropagation.DragObjectAndDropInInnerTarget();
            var innerText = droppablePagePreventPropagation.GetInnerTargetObjectTextNode();
            var outerText = droppablePagePreventPropagation.GetOuterTargetObjectTextNode();
            //Assert.AreEqual("Dropped!", InnerText);
            //Assert.AreEqual("Outer droppable", OuterText);
            "Dropped!".Should().Be(innerText);
            "Outer droppable".Should().Be(outerText);
        }

        [Test]
        public void DragElementByPixels()
        {
            var draggablePageDefault = new DraggablePageDefault(Driver);
            draggablePageDefault.NavigateTo();
            var startPositionX = draggablePageDefault.ObjectCurrentPosition().X;
            var startPositionY = draggablePageDefault.ObjectCurrentPosition().Y;
            draggablePageDefault.DragObjectByPixels();
            var endPositionX = draggablePageDefault.ObjectCurrentPosition().X;
            var endPositionY = draggablePageDefault.ObjectCurrentPosition().Y;
            //Assert.AreEqual(startPositionX + 50, endPositionX);
            //Assert.AreEqual(startPositionY + 250, endPositionY);
            (startPositionX + 50).Should().Be(endPositionX);
            (startPositionY + 250).Should().Be(endPositionY);
        }

        [Test]
        public void DragElementVertically()
        {
            var draggablePageConstrainMovement = new DraggablePageConstrainMovement(Driver);
            draggablePageConstrainMovement.NavigateTo();
            draggablePageConstrainMovement.OpenSecondTab();
            var startPositionX = draggablePageConstrainMovement.ObjectCurrentPosition().X;
            draggablePageConstrainMovement.DragObjectVertically();
            var endPositionX = draggablePageConstrainMovement.ObjectCurrentPosition().X;
            //Assert.AreEqual(startPositionX, endPositionX);
            startPositionX.Should().Be(endPositionX);
        }

        [Test]
        public void ResizableObject()
        {
            var resizablePage = new ResizablePage(Driver);
            resizablePage.NavigateTo();
            var elementH = resizablePage.GetSize().Height;
            var elementW = resizablePage.GetSize().Width;
            resizablePage.ResizeObject();
            //Assert.That(_resizablePage.GetSize().Height, Is.InRange(elementH + 10, elementH + 50));
            //Assert.That(_resizablePage.GetSize().Width, Is.InRange(elementW + 10, elementW + 50));
            resizablePage.GetSize().Height.Should().BeInRange(elementH + 10, elementH + 50);
            resizablePage.GetSize().Width.Should().BeInRange(elementW + 10, elementW + 50);
        }

        [Test]
        public void SelectElement()
        {
            var selectablePageDefault = new SelectablePageDefault(Driver);
            selectablePageDefault.NavigateTo();
            selectablePageDefault.SelectFirstLI();
            bool isContain = selectablePageDefault.ContainSelectableClass();
            //Assert.IsTrue(isContain);
            isContain.Should().BeTrue();
        }

        [Test]
        public void ReorderElement()
        {   //Arange
            var sortablePageDefault = new SortablePageDefault(Driver);
            sortablePageDefault.NavigateTo();

            //Act
            sortablePageDefault.ClickAndMoveElement();
            var text = sortablePageDefault.GetElementText();

            //Assert
            "Item 1".Should().Be(text);
        }
    }
}