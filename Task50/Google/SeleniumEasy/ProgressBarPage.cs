using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Task50Pages.SeleniumEasy;

internal class ProgressBarPage : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";
    const string DOWNLOAD_BUTTON_LOCATOR = "cricle-btn";
    const string PERCENT_TEXT_LOCATOR = ".percenttext";
    public ProgressBarPage(IWebDriver driver) : base(driver)
    {
        driver.Url = URL;
    }

    public ProgressBarPage? RestartPage()
    {
        try
        {
            GetElementById(DOWNLOAD_BUTTON_LOCATOR).Click();

            var specifiedText = new WebDriverWait(_driver, TimeSpan.FromSeconds(15))
                .Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector(PERCENT_TEXT_LOCATOR), "50%") );
           
            return new ProgressBarPage(_driver);
        }
        catch (NoSuchElementException)
        {
            return null;
        }
        catch (TimeoutException)
        {
            return null;
        }
    }
}
