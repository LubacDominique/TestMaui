using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Notes
{
    public class BrowserTests
    {
        private IWebDriver? driver; // Make driver nullable

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver();
        }

        [Test]
        public void Test_GoogleSearch()
        {
            // Ensure driver is not null
            if (driver == null)
            {
                Assert.Fail("WebDriver not initialized.");
                return;
            }

            // Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Find the search box using its name attribute
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            // Enter text to search for
            searchBox.SendKeys("Hello, .NET MAUI!");

            // Submit the search
            searchBox.Submit();

            // Wait for a moment to see the results
            System.Threading.Thread.Sleep(5000); // Consider using explicit waits

            // Assert or perform further actions
            Assert.That(driver.PageSource.Contains("Hello, .NET MAUI!"));
            //Assert.IsTrue(driver.PageSource.Contains("Hello, .NET MAUI!"));
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Quit();
        }
    }
}
