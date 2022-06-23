using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace AutomationPractice;

internal class Environment
{
    private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>()
    {
        {"Firefox", new FirefoxDriver()},
        {"Chrome",  new ChromeDriver()},
        {"SelenoidFireFox",  new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new FirefoxOptions())},
        {"SelenoidChrome",  new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), new ChromeOptions())},
        {"SauceLabsFireFox", new SauceLabsSetUp().SetSauceLabsBrowser("Firefox") },
        {"SauceLabsChrome", new SauceLabsSetUp().SetSauceLabsBrowser("Chrome") }
    };
    private string Browser { get; set; }
    private string Platform { get; set; }

    private static IWebDriver driver;

    internal static IWebDriver Driver
    {
        get
        {
            return driver;
        }
        private set
        {
            driver = value;
        }
    }

    public Environment(string browser, string environment)
    {
        Platform = environment?.ToLower() ?? throw new ArgumentNullException(nameof(environment));
        Browser = browser?.ToLower() ?? throw new ArgumentNullException(nameof(browser));
    }

    internal void SetEnvironment()
    {
        if (Platform.Equals("local"))
        {
            switch (Browser)
            {
                case "firefox":
                    driver = Drivers["Firefox"];
                    break;

                case "chrome":
                    driver = Drivers["Chrome"];
                    break;

                default: throw new ArgumentException("No such browser");
            }
        } else if (Platform.Equals("selenoid"))
        {
            switch (Browser)
            {
                case "firefox":
                    driver = Drivers["SelenoidFireFox"];
                    break;

                case "chrome":
                    driver = Drivers["SelenoidChrome"];
                    break;

                default: throw new ArgumentException("No such browser");
            }
        }
        else if (Platform.Equals("saucelabs"))
        {
            switch (Browser)
            {
                case "firefox":
                    driver = Drivers["SauceLabsFireFox"];

                    break;

                case "chrome":
                    driver = Drivers["SauceLabsChrome"];

                    break;

                default: throw new ArgumentException("No such browser");
            }
        }
        else
        {
            throw new ArgumentException("Environment provided is unavailable");
        }
    }

    internal static void LoadApplication(string url)
    {
        Driver.Url = url;
    }

    internal static void CloseAllDrivers()
    {
        foreach (var key in Drivers.Keys)
        {
            Drivers[key].Quit();
        }
    }
}
