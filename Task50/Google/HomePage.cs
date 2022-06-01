using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google;

internal class HomePage : BaseClass
{
    const string LOGIN_BUTTON_LOCATOR = "//a[text()='Prisijungti']";
    const string TC_BUTTON_LOCATOR = "L2AGLb";
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    internal LoginPage NavigateToLogin()
    {
        GetElementByXPath(LOGIN_BUTTON_LOCATOR).Click();
        GetElementById(TC_BUTTON_LOCATOR).Click();

    }

    internal void PressTermsAndConditionsButton()
    {
        GetElementById(TC_BUTTON_LOCATOR).Click();
    }
}
