using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationPractice;

internal class BaseClass
{
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
        element.Click();
    }

    protected void SelectDropdownElementByValue(IWebElement element, string? value)
    {
        SelectElement selectElement = new SelectElement(element);
        selectElement.SelectByValue(value ?? throw new ArgumentNullException(nameof(value)));
    }
}
