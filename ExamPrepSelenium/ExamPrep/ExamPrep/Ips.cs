using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ExamPrep
{
    [TestFixture]
    class Ips
    {
        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }

        public IWebDriver Driver { get; set; }

        [Test]
        public void GetIps()
        {
            Driver.Url = "http://services.ce3c.be/ciprg/";
            var tBody = Driver.FindElement(By.TagName("tbody"));
            IList<IWebElement> tds = tBody.FindElements(By.TagName("td"));
            List<string> countries = new List<string>();
            foreach (var t in tds)
            {
                var cName = t.FindElement(By.TagName("a")).Text;
                if (cName.Length != 0)
                {
                    countries.Add(cName);
                }
            }


            foreach (var c in countries)
            {
                Driver.Url = "http://services.ce3c.be/ciprg/";
                var inputBox = Driver.FindElement(By.XPath("//input[contains(@name,\'countrys\')]"));
                var radio = Driver.FindElement(By.XPath("//input[contains(@value,\'peerguardian\')]"));
                var generatebtn = Driver.FindElement(By.XPath("//input[contains(@value,\'Generate\')]"));
                inputBox.Clear();
                inputBox.SendKeys(c);
                radio.Click();
                generatebtn.Click();
                Thread.Sleep(500);
                var result = Driver.FindElement(By.TagName("pre")).Text;
                string createText = result;
                File.WriteAllText($"../../../CountryIP/{c.Replace(':','-')}.txt", createText);
            }
        }
    }
}
