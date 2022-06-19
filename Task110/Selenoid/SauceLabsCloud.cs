using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using Google;

namespace Selenoid;

internal class SauceLabsCloud : TestBaseClass
{
    private const string SEARCH_TEXT = "Selenium";

    [SetUp]
    public void SetUp()
    {
        var browserOptions = SetSafari();

        var sauceOptions = new Dictionary<string, object>();
        sauceOptions.Add("username", "oauth-vitagriciute-33166");
        sauceOptions.Add("accessKey", "c88e383d-b09e-4efa-bc5f-b165eb6ccba1");
        browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

        var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
        _driver = new RemoteWebDriver(uri, browserOptions);
    }

    [Test]
    public void TestBrowser()
    {
        HomePage homePage = new HomePage(_driver);

        try
        {
            Assert.IsTrue(homePage.IsLoaded(), "Home page was not loaded");
            var searchPage = homePage.Search(SEARCH_TEXT);
            Assert.IsTrue(searchPage.IsLoaded(), "Search page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}
