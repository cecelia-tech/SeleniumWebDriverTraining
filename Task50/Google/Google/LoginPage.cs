using OpenQA.Selenium;

namespace Task50Pages;

internal class LoginPage : BaseClass
{
    const string EMAIL_INPUT_LOCATOR = "identifierId";
    const string EMAIL_NEXT_BUTTON_LOCATOR = "//div[@id='identifierNext']//button";
    const string PASSWORD_INPUT_LOCATOR = "//input[@name='password']";
    const string PASSWORD_NEXT_BUTTON_LOCATOR = "//div[@id='passwordNext']//button";

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public HomePageAfterLogin Login(string username, string password)
    {
        GetElementById(EMAIL_INPUT_LOCATOR).SendKeys(username);
        GetElementByXPath(EMAIL_NEXT_BUTTON_LOCATOR).Click();
        GetElementByXPath(PASSWORD_INPUT_LOCATOR).SendKeys(password);
        GetElementByXPath(PASSWORD_NEXT_BUTTON_LOCATOR).Click();

        return new HomePageAfterLogin(_driver);
    }

}
