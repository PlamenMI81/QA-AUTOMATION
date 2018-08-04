using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SeleniumTests
{
    public class GoogleSearch
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.bg/");
            driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium" + Keys.Enter);
            driver.FindElement(By.PartialLinkText("Selenium - Web Browser Automation")).Click();
            Assert.Equal("Selenium - Web Browser Automation", driver.Title);
            driver.Close();
            driver.Quit();
        }
    }

    public class QAAutomationCourse
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://softuni.bg/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.CssSelector("li.dropdown-item:nth-child(2) > a:nth-child(1)")).Click();
            driver.FindElement(By.PartialLinkText("QA Automation - ώνθ 2018")).Click();
            var el = driver.FindElements(By.XPath("//*[contains(text(), 'QA Automation - ώνθ 2018')]"));
            var count = 0;
            foreach (var element in el)
            {
                if (element.TagName == "h1" || element.TagName == "h2")
                {
                    count++;
                }
            }
            Assert.Equal(1, count);
            driver.Close();
            driver.Quit();
        }
    }

    public class DemoQARegistrationPage
    {
        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("http://www.demoqa.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Registration")).Click();
            Assert.Contains("Registration | Demoqa", driver.Title);
            driver.Close();
            driver.Quit();
        }
    }

    public class DemoQARegistrationNegativeTests : IDisposable
    {
        string er1 = "* This field is required";
        string er2 = "* Minimum 10 Digits starting with Country Code";
        string er3 = "* Invalid email address";
        string er4 = "* Minimum 8 characters required";
        string er5 = "* Fields do not match";
        private IWebDriver driver;
       
        public void Dispose()
        {
            driver.Quit();
        }

        public DemoQARegistrationNegativeTests()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("http://www.demoqa.com/registration/");
            driver.Manage().Window.Maximize();
        }

        [Fact]
        public void CheckErrMsg1()
        {
            var nameInput = driver.FindElement(By.Id("name_3_firstname"));
            nameInput.Click();
            nameInput.SendKeys(Keys.Tab);
            var errMsg = driver.FindElement(By.CssSelector("div.legend_txt:nth-child(4) > span:nth-child(1)")).Text;
            Assert.Contains(er1, errMsg);
        }

        [Fact]
        public void CheckErrMsg2()
        {
            var phoneInput = driver.FindElement(By.Id("phone_9"));
            phoneInput.Click();
            phoneInput.SendKeys("0");
            phoneInput.SendKeys(Keys.Tab);
            var errMsg = driver.FindElement(By.CssSelector("li.fields:nth-child(6) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1)")).Text;
            Assert.Contains(er2, errMsg);
        }
        [Fact]
        public void CheckErrMsg3()
        {
            var emailInput = driver.FindElement(By.Id("email_1"));
            emailInput.Click();
            emailInput.SendKeys("a" + Keys.Tab);
            var errMsg = driver.FindElement(By.CssSelector("li.fields:nth-child(8) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1)")).Text;
            Assert.Contains(er3, errMsg);
        }
        [Fact]
        public void CheckErrMsg4()
        {
            var passinput = driver.FindElement(By.Id("password_2"));
            passinput.Click();
            passinput.SendKeys("a" + Keys.Tab);
            var errMsg = driver.FindElement(By.CssSelector("li.fields:nth-child(11) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1)")).Text;
            Assert.Contains(er4, errMsg);
        }
        [Fact]
        public void CheckErrMsg5()
        {
            var passInput = driver.FindElement(By.Id("password_2"));
            passInput.Click();
            passInput.SendKeys("a");
            var confPassInput = driver.FindElement(By.Id("confirm_password_password_2"));
            confPassInput.Click();
            confPassInput.SendKeys("b" + Keys.Tab);
            var errMsg = driver.FindElement(By.CssSelector("li.fields:nth-child(12) > div:nth-child(1) > div:nth-child(3) > span:nth-child(1)")).Text;
            Assert.Contains(er5, errMsg);
        }
    }
}
