using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Yandex;

internal class HomePageAfterLogin : BaseClass
{
    const string TITLE = "Yandex";
    const string URL = "https://yandex.lt/";

    [FindsBy(How =How.CssSelector, Using = ".username")]
    IWebElement UsernameLink;

    public HomePageAfterLogin(IWebDriver driver) : base(driver)
    {
        //Load();
    }

    public void Load()
    {
        _driver.Url = URL;
    }

    public bool IsLoaded()
    {
        return _driver.Title.Equals(TITLE);
    }
    public bool IsLoggedIn()
    {
        try
        {
            return UsernameLink.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
