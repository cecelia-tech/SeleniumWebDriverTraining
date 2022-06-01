using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Google;

internal abstract class BaseClass
{

    private IWebDriver _driver;
    public BaseClass(IWebDriver driver)
    {
        _driver = driver;
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
}
