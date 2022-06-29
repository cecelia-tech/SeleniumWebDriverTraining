using OpenQA.Selenium;

namespace Google;

internal class FrontPage : BaseClass
{
    const string LOGIN_BUTTON_LOCATOR = "//a[text()='Prisijungti']";
    const string TC_BUTTON_LOCATOR = "L2AGLb";

    public FrontPage(IWebDriver driver) : base(driver)
    {
    }

    internal void PressLoginButton()
    {
        GetElementByXPath(LOGIN_BUTTON_LOCATOR).Click();
    }

    internal void PressTermsAndConditionsButton()
    {
        GetElementById(TC_BUTTON_LOCATOR).Click();
    }
}
