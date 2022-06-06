using OpenQA.Selenium;

namespace Task50Pages;

internal abstract class BaseClass
{
    protected IWebDriver _driver;
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    internal IWebElement GetElementByXPath(string path)
    {
        IWebElement webElement = _driver.FindElement(By.XPath(path));

        return webElement;
    }

    internal IWebElement GetElementById(string id)
    {
        IWebElement webElement = _driver.FindElement(By.Id(id));

        return webElement;
    }
    internal IWebElement GetElementByCSS(string cssSelector)
    {
        IWebElement webElement = _driver.FindElement(By.CssSelector(cssSelector));

        return webElement;
    }
}
