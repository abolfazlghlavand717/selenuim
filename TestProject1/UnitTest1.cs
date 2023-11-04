using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace TestProject1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            //var driverPath = ChromeDriverPath.GetChromeDriverPath();
            //var service = ChromeDriverService.CreateDefaultService(driverPath: driverPath);
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
        }

        [Test]
        public void Test1()
        {

            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            driver.FindElement(By.Name("my-password")).SendKeys("csharp code");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("my-text")).SendKeys("qa code");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//textarea[@class='form-control']")).SendKeys("php code");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//select[@name='my-select']/option[@value='2']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='my-datalist']")).SendKeys("New York");
            Thread.Sleep(3000);

            driver.FindElement(By.Name("my-date")).Click();
            var year = driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']//thead//th[@class='datepicker-switch']")).Text;
            Thread.Sleep(2000);
            var next = driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']//thead//th[@class='next']"));
            Thread.Sleep(2000);
            while (year != "January 2024")
            {
                next.Click();
                Thread.Sleep(2000);
                year = driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']//thead//th[@class='datepicker-switch']")).Text;
                Thread.Sleep(2000);
            }
            driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']//tr//td[text()='1']")).Click();

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='my-check']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("my-check-2")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("my-check-1")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@class='btn btn-outline-primary mt-3']")).Click();
            Thread.Sleep(3000);
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            driver.FindElement(By.XPath("//input[@name='my-datalist']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@name='my-datalist']")).SendKeys("New York");
            Assert.Pass();
        }

        [TearDown] public void TearDown()
        {
            Thread.Sleep(50000);
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Calender()
        {
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.XPath("//input[@name='my-date']")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='datepicker-days']/parent::*")));
            var yearMonth = driver.FindElement(By.XPath("//th[@class='datepicker-switch']")).Text;


            while (yearMonth != "July 2026")
            {
                driver.FindElement(By.XPath("//th[@class='next']")).Click();
                yearMonth = driver.FindElement(By.XPath("//th[@class='datepicker-switch']")).Text;
                Thread.Sleep(500);
            }
            driver.FindElement(By.XPath("//div[@class='datepicker-days']//table[@class='table-condensed']//tr//td[text()='20']")).Click();
            Assert.IsTrue(yearMonth == "July 2026");
        }

        [Test]
        public void Alibaba()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.alibaba.ir/");

           var source = driver.FindElement(By.XPath("//div[@role='tabpanel']//input[starts-with(@id,'al')]"));
            source.Click();

            driver.FindElement(By.XPath("//li[@data-value='AWZ']")).Click();
         
            driver.FindElement(By.XPath("//div[@role='tabpanel']/descendant-or-self::input[starts-with(@id,'al')][2]")).Click();
          
            driver.FindElement(By.XPath("//li[@data-value='THR']")).Click();
         
            driver.FindElement(By.XPath("//button[@class='btn is-sm is-link']")).Click();
          
           var click= driver.FindElement(By.XPath("//div[@class='datepicker-arrows']//button[1]"));
            
            var monthName = driver.FindElement(By.XPath("//div[contains(@class,'datepicker-slide')]//div[contains(@class,'calendar')][2]//h5")).Text;
            
            while(monthName != "April")
            {
                click.Click();
                monthName = driver.FindElement(By.XPath("//div[contains(@class,'datepicker-slide')]//div[contains(@class,'calendar')][2]//h5")).Text;
            }

            Assert.IsTrue(monthName== "April");
        }
    }
}
