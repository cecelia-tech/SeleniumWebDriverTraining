using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Google;

internal class HomePage : BaseClass
{
    private const string URL = "https://www.google.com/";

    [FindsBy(How = How.Id, Using = "L2AGLb")]
    IWebElement TermsConditionsButton;
    [FindsBy(How = How.XPath, Using = "//input[@name = 'q']")]
    IWebElement SearchInput;
    [FindsBy(How = How.XPath, Using = "//div[@class='CqAVzb lJ9FBc']/center/input[1]")]
    IWebElement SearchButton;

    public HomePage(IWebDriver driver) : base(driver)
    {
        Load();
    }

    internal SearchPage Search(string searchText)
    {
        AcceptTermsConditions();
        SetSearchText(searchText);
        ClickSearch();

        return new SearchPage(_driver);
    }

    private void AcceptTermsConditions()
    {
        TermsConditionsButton.Click();
    }

    private void SetSearchText(string text)
    {
        SearchInput.SendKeys(text);
    }

    private void ClickSearch()
    {
        SearchButton.Click();
    }

    internal bool IsLoaded()
    {
        return _driver.Title.Contains("Google");
    }

    internal void Load()
    {
        _driver.Url = URL;
    }
}
