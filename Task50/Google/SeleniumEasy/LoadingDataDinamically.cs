using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task50Pages.SeleniumEasy;

internal class LoadingDataDinamically : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";
    const string GET_NEW_USER_BUTTON_LOCATOR = "save";
    const string NEW_USER_LOCATOR = "loading";
    public LoadingDataDinamically(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    public bool IsNewUserDisplayed()
    {
        GetElementById(GET_NEW_USER_BUTTON_LOCATOR).Click();

        try
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
           .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(NEW_USER_LOCATOR)));

            return true;
        }
        catch (TimeoutException)
        {
            return false;
        }
       
    }
}
