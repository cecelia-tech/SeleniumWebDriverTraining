using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Google;

internal class SearchPage : BaseClass
{
    private const string RESULTS_STATS_LOCATOR = "result-stats";

    public SearchPage(IWebDriver driver) : base(driver)
    {
    }

    internal bool IsLoaded()
    {
        try
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.Id(RESULTS_STATS_LOCATOR)));

            return true;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }
}
