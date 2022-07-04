using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Google;

internal abstract class BaseClass
{
    internal IWebDriver _driver { get; private set; }

    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

}
