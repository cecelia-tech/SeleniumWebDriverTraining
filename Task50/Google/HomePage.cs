using OpenQA.Selenium;

namespace Google;

internal class HomePage : BaseClass
{
    const string URL = "https://www.google.com";
    const string LOGIN_BUTTON_LOCATOR = "//a[text()='Prisijungti']";
    const string TC_BUTTON_LOCATOR = "L2AGLb";
    
    public HomePage(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    internal LoginPage NavigateToLogin()
    {
        GetElementById(TC_BUTTON_LOCATOR).Click();
        GetElementByXPath(LOGIN_BUTTON_LOCATOR).Click();
        
        return new LoginPage(_driver);
    }

}
