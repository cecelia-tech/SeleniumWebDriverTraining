using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace Selenoid;

internal class TestBaseClass
{
    protected IWebDriver _driver;

    internal EdgeOptions SetEdge()
    {
        var browserOptions = new EdgeOptions();
        browserOptions.PlatformName = "Windows 10";
        browserOptions.BrowserVersion = "latest";
        return browserOptions;
    }

    internal FirefoxOptions SetFireFox()
    {
        var browserOptions = new FirefoxOptions();
        browserOptions.PlatformName = "Windows 8.1";
        browserOptions.BrowserVersion = "latest";
        return browserOptions;
    }

    internal SafariOptions SetSafari()
    {
        var browserOptions = new SafariOptions();
        browserOptions.PlatformName = "macOS 10.15";
        browserOptions.BrowserVersion = "latest";
        return browserOptions;
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
