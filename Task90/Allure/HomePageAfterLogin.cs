using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Yandex;

internal class HomePageAfterLogin : BaseClass
{
    const string TITLE = "Yandex";

    [FindsBy(How = How.CssSelector, Using = ".username")]
    IWebElement UsernameLink;

    public HomePageAfterLogin(IWebDriver driver) : base(driver)
    {
    }

    public bool IsLoaded()
    {
        try
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
            .Until((condition) => _driver.Title.Equals(TITLE));
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
    public bool IsLoggedIn()
    {
        try
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
                .Until((condition) =>
                {
                    return UsernameLink.Displayed;
                });
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
}