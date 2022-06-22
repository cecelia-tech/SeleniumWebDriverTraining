using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace AutomationPractice;

internal class BrowserFactory
{
    private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>()
    {
        {"Firefox", new FirefoxDriver()},
        {"Chrome",  new ChromeDriver()}
    };

    private static IWebDriver driver;

    public static IWebDriver Driver
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

    public BrowserFactory(string browser, string environment)
    {

    }

    private void SetEnvironment(string environment, string browser)
    {
        if (environment.ToLower().Equals("local"))
        {
            switch (browser)
            {
                case "Firefox":
                    driver = Drivers["Firefox"];
                    break;

                case "Chrome":
                    driver = Drivers["Chrome"];
                    break;

                default: throw new ArgumentException("No such browser");
            }
        } else if (environment.ToLower().Equals("selenoid"))
        {
            switch (browser)
            {
                case "Firefox":
                    var fireFoxOptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), fireFoxOptions);
                    break;

                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                    break;

                default: throw new ArgumentException("No such browser");
            }
        }
        else if (environment.ToLower().Equals("saucelabs"))
        {
            switch (browser)
            {
                case "Firefox":
                    var browserOptions = new FirefoxOptions();
                    browserOptions.PlatformName = "Windows 10";
                    browserOptions.BrowserVersion = "latest";
                    var sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("username", "oauth-vitagriciute-33166");
                    sauceOptions.Add("accessKey", "c88e383d-b09e-4efa-bc5f-b165eb6ccba1");
                    browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

                    var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
                    driver = new RemoteWebDriver(uri, browserOptions);
                    break;

                case "Chrome":
                    var fireFoxOptions = new FirefoxOptions();
                    fireFoxOptions.PlatformName = "Windows 10";
                    fireFoxOptions.BrowserVersion = "latest";
                    
                    break;

                default: throw new ArgumentException("No such browser");
            }
        }

        

        switch (environment)
        {
            case "Local":
                driver = Drivers["Firefox"];
                break;

            case "Selenoid":
                driver = Drivers["Chrome"];
                break;

            case "SauceLabs":
                driver = Drivers["Chrome"];
                break;

            default: throw new ArgumentException("No such browser");
        }
    }

    private RemoteWebDriver AssignSauceLabsSetup()
    {
        var sauceOptions = new Dictionary<string, object>();
        sauceOptions.Add("username", "oauth-vitagriciute-33166");
        sauceOptions.Add("accessKey", "c88e383d-b09e-4efa-bc5f-b165eb6ccba1");
        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

        var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
        return new RemoteWebDriver(uri, browserOptions);
    }

    public static void SetBrowser(string browserName)
    {
        switch (browserName)
        {
            case "Firefox":
                driver = Drivers["Firefox"];
                break;

            case "Chrome":
                driver = Drivers["Chrome"];
                break;

                default: throw new ArgumentException("No such browser");
        }
    }

    public static void LoadApplication(string url)
    {
        Driver.Url = url;
    }

    public static void CloseAllDrivers()
    {
        foreach (var key in Drivers.Keys)
        {
            Drivers[key].Quit();
        }
    }
}
