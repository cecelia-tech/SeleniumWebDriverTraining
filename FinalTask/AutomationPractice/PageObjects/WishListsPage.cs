﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice.PageObjects;

public class WishListsPage : BaseClass, ILoad<WishListsPage>
{
    const string WISHLIST_URL = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
    [FindsBy(How = How.Id, Using = "name")]
    private IWebElement myWishListInput;
    [FindsBy(How =How.Id, Using = "submitWishlist")]
    private IWebElement saveButton;
    [FindsBy(How = How.CssSelector, Using = "li.clearfix > a")]
    private IWebElement productToAddToCartLocator;
    [FindsBy(How = How.XPath, Using = "//a[contains(text(),'My wishlist')]")]
    private IWebElement autoGeneratedWishlistElement;
    [FindsBy(How = How.CssSelector, Using = "a[class='icon']")]
    private IWebElement deleteWishlist;
    private By autoGeneratedWishlistBy = By.XPath("//a[contains(text(),'My wishlist')]");
     
    public WishListsPage CreateMyWishList(string name)
    {
        SetInputValue(myWishListInput, name);
        ClickElement(saveButton);
        return Page.WishLists;
    }

    public bool DoesCustomWishlistWasCreated(string wishlistName)
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.LinkText(wishlistName))).Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DoesAutoGeneratedWishListExist()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(autoGeneratedWishlistBy)).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public ProductPage ClickProduct()
    {
        ClickElement(productToAddToCartLocator);
        return Page.ProductPage;
    }

    public bool CheckProductAddedToAutoWishList()
    {
        try
        {
            ClickElement(autoGeneratedWishlistElement);

            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Printed Chiffon Dress')]"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public WishListsPage DeleteWishList()
    {
        try
        {
            new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementToBeClickable(deleteWishlist)).Click();

            return this;
        }
        catch (WebDriverTimeoutException)
        {
            return this;
        }
    }

    public bool CheckProductAddedToCustomWishList(string wishList)
    {
        try
        {
            BrowserEnvironment.Driver.FindElement(By.XPath($"//a[contains(text(),'{wishList}')]")).Click();

            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Printed Chiffon Dress')]"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public WishListsPage LoadPage()
    {
        BrowserEnvironment.LoadApplication(WISHLIST_URL);
        return Page.WishLists;
    }

    public bool IsPageLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("mywishlist"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
