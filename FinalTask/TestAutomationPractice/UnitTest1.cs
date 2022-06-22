using AutomationPractice;
using NUnit.Framework;

namespace TestAutomationPractice;

public class Tests
{
    private const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
    [OneTimeSetUp]
    public void Setup()
    {
        BrowserFactory.InitBrowser("Chrome");
        BrowserFactory.LoadApplication(URL);
    }

    [Test]
    public void Test1()
    {
        
    }
}
