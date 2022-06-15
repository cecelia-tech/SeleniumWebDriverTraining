using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Selenoid;

public class Tests
{
    private WebDriver _driver;
    private const string TEST_URL = "https://www.google.com/";
    
    [SetUp]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
    }

    [Test]
    public void Test1()
    {
        _driver.Url = TEST_URL;
        _driver.FindElement(By.Id("L2AGLb")).Click();
        var searchBar = _driver.FindElement(By.XPath("//input[@name = 'q']"));
        //searchBar.Click();
        searchBar.SendKeys("Selenoid");
        TakeScreenShotAsFile("sample");
    }

    private void TakeScreenShotAsFile(string filename)
    {
        Screenshot savedImage = ((ITakesScreenshot)_driver).GetScreenshot();
        savedImage.SaveAsFile($"C:\\Users\\VitaGriciute\\source\\repos\\SeleniumWebDriverTraining\\Task110\\Selenoid\\ScreenShots\\{filename}.png", ScreenshotImageFormat.Png);
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
