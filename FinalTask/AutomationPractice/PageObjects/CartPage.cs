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

public class CartPage : BaseClass, ILoad<CartPage>
{
    private const string URL = "http://automationpractice.com/index.php?controller=order";
    [FindsBy(How = How.Id, Using = "total_price")]
    private IWebElement totalPrice;

    private By productsInTheCart = By.XPath("//tr[contains(@id, 'product')]");
    private By cartHeadline = By.Id("cart_title");

    public int CountProductsInTheCart()
    {
        return BrowserEnvironment.Driver.FindElements(productsInTheCart).Count();
    }

    public double GetCartTotal()
    {
        return double.Parse(totalPrice.Text.TrimStart('$'));
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(cartHeadline)).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public CartPage LoadPage()
    {
        BrowserEnvironment.Driver.Url = URL;

        return Page.CartPage;
    }
}
