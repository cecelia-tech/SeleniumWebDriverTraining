using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public class BaseClass
{
    [FindsBy(How = How.ClassName, Using = "account")]
    private IWebElement userHomePage;
    
    //protected IWebDriver _driver;

    //public BaseClass(IWebDriver driver)
    //{
    //    _driver = driver;
    //    PageFactory.InitElements(_driver, this);
    //}

    protected void SetInputValue(IWebElement element, string? value)
    {
        element.Clear();
        element.SendKeys(value ?? throw new ArgumentNullException(nameof(value)));
    }

    protected void ClickElement(IWebElement element)
    {
        new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(element));

        element.Click();
    }

    protected void MoveMouse(IWebElement element)
    {
        Actions action = new Actions(BrowserEnvironment.Driver);

        action.MoveToElement(element).Perform();
    }

    protected void SelectDropdownElementByText(IWebElement element, string? value)
    {
        SelectElement selectElement = new SelectElement(element);
        selectElement.SelectByText(value ?? throw new ArgumentNullException(nameof(value)));
    }

    public UserHomePage GoToUserHomePage()
    {
        ClickElement(userHomePage);
        return Page.UserHomePage;
    }


}
