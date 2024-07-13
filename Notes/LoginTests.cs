using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace Notes
{
    public class LoginTests
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_Login()
        {
            if (driver == null)
            {
                Assert.Fail("WebDriver not initialized.");
                return;
            }
            // Assuming you have the HTML file saved locally
            string localFilePath = new Uri(Path.Combine(Directory.GetCurrentDirectory(), "login.html")).AbsoluteUri;
            driver.Navigate().GoToUrl(localFilePath);

            // Find and fill the username
            driver.FindElement(By.Name("uname")).SendKeys("testuser");

            // Find and fill the password
            driver.FindElement(By.Name("psw")).SendKeys("password");

            // Click the login button
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Add your assertions here
            // For example, to check if the login was successful by verifying a redirect or checking for a logout button
            // Assert.IsTrue(driver.FindElement(By...));
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Quit();
        }
    }
}
