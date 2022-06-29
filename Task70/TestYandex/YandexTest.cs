namespace TestYandex;

public class Tests : TestBaseClass
{
    [Test]
    public void TestYandexLogin()
    {
        HomePage homePage = new HomePage(_driver);
        Assert.True(homePage.IsLoaded(), "Home page is not loaded");
        var loginPage = homePage.ClickLogIn();
        Assert.IsTrue(loginPage.IsLoaded(), "Login page is not loaded");
        var homePageAfterLogin = loginPage.LogIn("SeleniumTest789@yandex.com", "belekoks_789!");
        Assert.IsTrue(homePageAfterLogin.IsLoaded(), "Home page after login not loaded");

        TakeScreenShotAsFile("example1");

        Assert.IsTrue(homePageAfterLogin.IsLoggedIn(), "Username link is not loaded");
    }
}
