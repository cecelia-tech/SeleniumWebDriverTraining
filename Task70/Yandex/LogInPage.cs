using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Yandex;

internal class LogInPage : BaseClass
{
    const string TITLE = "Authorization";
    [FindsBy(How = How.Id, Using = "passp-field-passwd")]
    IWebElement PasswordInput;
    [FindsBy(How = How.Id, Using = "passp-field-login")]
    IWebElement UsernameInput;
    [FindsBy(How = How.Id, Using = "passp:sign-in")]
    IWebElement LoginButton;
    public LogInPage(IWebDriver driver) : base(driver)
    {
    }

    public HomePageAfterLogin LogIn(string username, string password)
    {
        UsernameInput.SendKeys(username);
        LoginButton.Click();
        Thread.Sleep(1000);
        PasswordInput.SendKeys(password);
        LoginButton.Click();

        return new HomePageAfterLogin(_driver);
    }

    public bool IsLoaded()
    {
        return _driver.Title.Equals(TITLE);
    }
}
