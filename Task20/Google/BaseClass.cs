using OpenQA.Selenium;

namespace Google;

internal abstract class BaseClass
{
    protected const string USERNAME = "jcecelia72@gmail.com";
    protected const string PASSWORD = "KadIrKas_Bebutu63!";

    internal IWebDriver _driver;
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
    }

    internal IWebElement GetElementByXPath(string path)
    {
        IWebElement? webElement = null;

        while (webElement == null)
        {
            try
            {
                webElement = _driver.FindElement(By.XPath(path));
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
            }
        }
        return webElement;
    }

    internal IWebElement GetElementById(string id)
    {
        IWebElement webElement = _driver.FindElement(By.Id(id));

        return webElement;
    }

    internal IWebElement GetElementByClassName(string className)
    {
        IWebElement webElement = _driver.FindElement(By.ClassName(className));

        return webElement;
    }

    internal IWebElement GetElementBylLinkText(string linkText)
    {
        IWebElement webElement = _driver.FindElement(By.LinkText(linkText));

        return webElement;
    }

    internal IWebElement GetElementByPartialLinkText(string partialLinkText)
    {
        IWebElement webElement = _driver.FindElement(By.PartialLinkText(partialLinkText));

        return webElement;
    }

    internal IWebElement GetElementByTagName(string tagName)
    {
        IWebElement webElement = _driver.FindElement(By.TagName(tagName));

        return webElement;
    }

    internal IWebElement GetElementByCssSelector(string cssSelector)
    {
        IWebElement webElement = _driver.FindElement(By.CssSelector(cssSelector));

        return webElement;
    }

    internal IWebElement GetElementByName(string name)
    {
        IWebElement webElement = _driver.FindElement(By.Name(name));

        return webElement;
    }
}
