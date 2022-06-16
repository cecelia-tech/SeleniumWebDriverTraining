using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Google;

namespace Selenoid;

public class SelenoidTests
{
    private IWebDriver _driver;
    private const string SEARCH_TEXT = "Selenium";

    [SetUp]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
    }

    [Test]
    public void TestSearchResultsLoaded()
    {
        HomePage homePage = new HomePage(_driver);

        try
        {
            Assert.IsTrue(homePage.IsLoaded(), "Home page was not loaded");
            var searchPage = homePage.Search(SEARCH_TEXT);
            Assert.IsTrue(searchPage.IsLoaded(), "Search page was not loaded");

            TakeScreenShotAsFile(SEARCH_TEXT);
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
