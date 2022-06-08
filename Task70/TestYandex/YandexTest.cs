

namespace TestYandex;

public class Tests
{
    IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestYandexLogin()
    {
        HomePage homePage = new HomePage(_driver);
        homePage.Load();
        Assert.True(homePage.IsLoaded(), "Home page is not loaded");
        var loginPage = homePage.ClickLogIn();
        Assert.IsTrue(loginPage.IsLoaded(), "Login page is not loaded");
        var homePageAfterLogin = loginPage.LogIn("SeleniumTest789@yandex.com", "belekoks_789!");
        Assert.IsTrue(homePageAfterLogin.IsLoaded(), "Home page after login not loaded");
        Assert.IsTrue(homePageAfterLogin.IsLoggedIn(), "Username link is not loaded");
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
