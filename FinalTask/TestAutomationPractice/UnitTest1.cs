using AutomationPractice;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestAutomationPractice;

public class Tests
{
    private const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
    
    [OneTimeSetUp]
    public void Setup()
    {
        Environment.SetBrowser("Chrome");
        
    }

    [Test]
    public void Test1()
    {
        Environment.LoadApplication(URL);
        var signupPage = Page.Login.SubmitEmailForm("sample@sample1.com");

    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        Environment.CloseAllDrivers();
    }
}
