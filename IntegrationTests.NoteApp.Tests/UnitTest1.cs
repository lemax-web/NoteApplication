using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace IntegrationTests.NoteApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver? _webDriver;

        [TestInitialize]
        public void setup()
        {
            //Setup
            new DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TestLoginPageTitle()
        {
            _webDriver?.Navigate().GoToUrl("https://localhost:7192/");
            Assert.IsTrue(_webDriver?.Title.Contains("List Note"));
        }
        [TestCleanup]
        public void TearDown()
        {
            // Teaar down
            _webDriver?.Quit();
        }
    }
}