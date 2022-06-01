namespace Tests;

[TestFixture]
public class TestBaseClass
{
    protected IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void CleanUp()
    {
        _driver.Quit();
    }
}
