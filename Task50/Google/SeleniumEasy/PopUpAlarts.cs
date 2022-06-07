using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task50Pages.SeleniumEasy;

internal class PopUpAlarts : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
    const string CONFIRM_BOX_BUTTON_LOCATOR = "//*[@id='confirm-demo']/preceding-sibling::button";
    const string CONFIRM_BOX_VALUE_LOCATOR = "confirm-demo";
    const string PROMPT_BOX_BUTTON_LOCATOR = "//p[@id='prompt-demo']/preceding-sibling::button";
    const string PROMPT_BOX_VALUE_LOCATOR = "prompt-demo";
    
    public PopUpAlarts(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    public string AcceptConfirmBox()
    {
        try
        {
            GetElementByXPath(CONFIRM_BOX_BUTTON_LOCATOR).Click();

            var alert = _driver.SwitchTo().Alert();
            alert.Accept();

            var text = new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until((IWebDriver) =>
            {
                var element = GetElementById(CONFIRM_BOX_VALUE_LOCATOR);
                return element.Text;
            });

            return text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
        catch (NoAlertPresentException)
        {
            return string.Empty;
        }
        catch (TimeoutException)
        {
            return string.Empty;
        }
        
    }

    public string DeclineConfirmBox()
    {
        try
        {
            GetElementByXPath(CONFIRM_BOX_BUTTON_LOCATOR).Click();

            var alert = _driver.SwitchTo().Alert();
            alert.Dismiss();

            var text = new WebDriverWait(_driver, TimeSpan.FromSeconds(5)).Until((IWebDriver) =>
            {
                var element = GetElementById(CONFIRM_BOX_VALUE_LOCATOR);
                return element.Text;
            });

            return text;
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
        catch (NoAlertPresentException)
        {
            return string.Empty;
        }
        catch (TimeoutException)
        {
            return string.Empty;
        }
    }

    public string AcceptPromptBoxAlert(string textForPromptBox)
    {
        try
        {
            GetElementByXPath(PROMPT_BOX_BUTTON_LOCATOR).Click();

            var alert = _driver.SwitchTo().Alert();
            alert.SendKeys(textForPromptBox);
            alert.Accept();

            WebDriverWait waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            Func<IWebDriver, string> waitForElementText = new Func<IWebDriver, string>((IWebDriver Web) =>
            {
                IWebElement element = GetElementById(PROMPT_BOX_VALUE_LOCATOR);

                return element.Text;
            });

            return waiter.Until(waitForElementText);
        }
        catch (NoSuchElementException)
        {
            return string.Empty;
        }
        catch (NoAlertPresentException)
        {
            return string.Empty;
        }
        catch (TimeoutException)
        {
            return string.Empty;
        }
    }
}
