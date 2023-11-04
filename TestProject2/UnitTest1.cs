using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject2
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var driverPath = ChromeDriverPath.GetDriver();
            var service = ChromeDriverService.CreateDefaultService(driverPath: driverPath);
            driver = new ChromeDriver(service);
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://yahoo.com");
            Assert.Pass();


        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}