using OpenQA.Selenium;

namespace Google;

internal class FrontPageAfterLogIn : BaseClass
{
    const string ACCOUNT_IMAGE_LOCATOR = "//div[@id='gb']//img";
    public FrontPageAfterLogIn(IWebDriver driver) : base(driver)
    {
    }

    internal bool CheckAccountImage()
    {
        return GetElementByXPath(ACCOUNT_IMAGE_LOCATOR).Displayed;
    }
}
