namespace TestYandex;

public class TestBaseClass
{
    public IWebDriver _driver { get; private set; }
   
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

    protected void TakeScreenShotAsFile(string filename)
    {
        Screenshot savedImage = ((ITakesScreenshot)_driver).GetScreenshot();
        savedImage.SaveAsFile($"{filename}.jpeg", ScreenshotImageFormat.Jpeg);
    }

    protected string TakeScreenShotAsString()
    {
        return ((ITakesScreenshot)_driver).GetScreenshot().AsBase64EncodedString;
    }

    protected byte[] TakeScreenShotAsBytes()
    {
        return ((ITakesScreenshot)_driver).GetScreenshot().AsByteArray;
    }
}
