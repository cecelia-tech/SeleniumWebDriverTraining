using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects;

public class ProductPage : BaseClass, ILoad
{
    [FindsBy(How = How.Id, Using = "wishlist_button")]
    private IWebElement wishListLink;
    [FindsBy(How = How.CssSelector, Using = "a[title='Close']")]
    private IWebElement popUpCloseButton;

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("bigpic"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void LoadPage()
    {
        throw new NotImplementedException();
    }

    public ProductPage AddToWishList()
    {
        ClickElement(wishListLink);

        new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[title='Close']"))).Click();

        return this;
    }
}
