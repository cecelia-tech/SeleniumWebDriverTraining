using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Yandex;

internal class HomePage : BaseClass
{
    const string TITLE = "Yandex";
    const string URL = "https://yandex.lt/";

    [FindsBy(How = How.CssSelector, Using = "a[class*='login-link']")]
    IWebElement LoginLink;

    public HomePage(IWebDriver driver) : base(driver)
    {
        Load();
    }

    public void Load()
    {
        _driver.Url = URL;
    }

    public bool IsLoaded()
    {
        return _driver.Title.Equals(TITLE);
    }

    public LogInPage ClickLogIn()
    {
        LoginLink.Click();
        return new LogInPage(_driver);
    }
}