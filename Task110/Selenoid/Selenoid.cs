using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Selenoid;

public class SelenoidTests
{
    private WebDriver _driver;
    private const string TEST_URL = "https://www.google.com/";
    private const string TERMS_CONDITIONS_BUTTON = "L2AGLb";
    private const string SEARCH_INPUT = "//input[@name = 'q']";

    [SetUp]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
    }

    [Test]
    public void Test1()
    {
        try
        {
            _driver.Url = TEST_URL;
            _driver.FindElement(By.Id(TERMS_CONDITIONS_BUTTON)).Click();
            _driver.FindElement(By.XPath(SEARCH_INPUT)).SendKeys("Selenoid");

            TakeScreenShotAsFile(_driver.Title);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }

    private void TakeScreenShotAsFile(string filename)
    {
        Screenshot savedImage = ((ITakesScreenshot)_driver).GetScreenshot();
        savedImage.SaveAsFile(@$"C:\Users\VitaGriciute\source\repos\SeleniumWebDriverTraining\Task110\Selenoid\ScreenShots\{filename}.png", ScreenshotImageFormat.Png);
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
