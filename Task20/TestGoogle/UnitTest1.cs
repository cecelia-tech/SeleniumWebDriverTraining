namespace TestGoogle;

public class Tests
{
    IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.google.com";
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void Test1()
    {
        FrontPage frontPage = new FrontPage(_driver);
        frontPage.PressTermsAndConditionsButton();
        frontPage.PressLoginButton();
        
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.SetEmailAdress();
        loginPage.PressEmailNextButton();
        loginPage.SetPassword();
        loginPage.PressPasswordNextButton();

        FrontPageAfterLogIn frontPageAfterLogIn = new FrontPageAfterLogIn(_driver);

        Assert.IsTrue(frontPageAfterLogIn.CheckAccountImage());
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
