using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityDemo
{
    class TestDemo
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Url = "http://www.google.com";
            Console.WriteLine("Open Browser");
        }

        [Test]
        public void VerifyGoogleHomePage()
        {            
            var element = driver.FindElement(By.Id("hplogo"));            
            Assert.IsTrue(element.Displayed);
            Console.WriteLine("Google page opened");
        }

        [Test]
        public void SearchGoogle()
        {
            var element = driver.FindElement(By.ClassName("gLFyf"));
            element.SendKeys("Brother International");
            
            var button = driver.FindElement(By.Name("btnK"));
            while (!button.Displayed) ;
            button.Click();
            Console.WriteLine("Searched Google for Brother");

            var elements = driver.FindElements(By.ClassName("g"));
            Assert.IsTrue(elements.Count > 0);
            Console.WriteLine("Searched results showed up for Brother");
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            Console.WriteLine("Browser closed");
        }
    }
}
