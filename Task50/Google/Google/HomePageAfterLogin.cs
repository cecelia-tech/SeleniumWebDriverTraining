using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Task50Pages;

internal class HomePageAfterLogin : BaseClass
{
    const string ACCOUNT_IMAGE_LOCATOR = "//div[@id='gb']//img";
    public HomePageAfterLogin(IWebDriver driver) : base(driver)
    {
        var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); 
        waiter.PollingInterval = TimeSpan.FromMilliseconds(500);
        waiter.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(ACCOUNT_IMAGE_LOCATOR)));
    }

    public bool CheckAccountImage()
    {
        try
        {
            return GetElementByXPath(ACCOUNT_IMAGE_LOCATOR).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
