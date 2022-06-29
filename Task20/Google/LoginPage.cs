using OpenQA.Selenium;

namespace Google;

internal class LoginPage : BaseClass
{
    const string EMAIL_INPUT_LOCATOR = "identifierId";
    const string EMAIL_NEXT_BUTTON_LOCATOR = "//div[@id='identifierNext']//button";
    const string PASSWORD_INPUT_LOCATOR = "//input[@name='password']";
    const string PASSWORD_NEXT_BUTTON_LOCATOR = "//div[@id='passwordNext']//button";


    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    internal void SetEmailAdress()
    {
        GetElementById(EMAIL_INPUT_LOCATOR).SendKeys(USERNAME);
    }

    internal void PressEmailNextButton()
    {
        GetElementByXPath(EMAIL_NEXT_BUTTON_LOCATOR).Click();
    }

    internal void SetPassword()
    {
        GetElementByXPath(PASSWORD_INPUT_LOCATOR).SendKeys(PASSWORD);
    }

    internal void PressPasswordNextButton()
    {
        GetElementByXPath(PASSWORD_NEXT_BUTTON_LOCATOR).Click();
    }
}
