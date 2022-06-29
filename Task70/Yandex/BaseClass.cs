using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Yandex;

internal class BaseClass
{
    protected IWebDriver _driver;

    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }
}
