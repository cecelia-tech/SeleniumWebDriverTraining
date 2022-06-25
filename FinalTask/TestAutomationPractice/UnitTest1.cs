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
        BrowserEnvironment.SetEnvironment("local", "chrome");
        
    }

    [Test]
    public void TestCreateAcount()
    {
        try
        {
            BrowserEnvironment.LoadApplication(URL);
            var signupPage = Page.Login.SubmitEmailForm("sample@sample.com");
            Assert.IsTrue(signupPage.IsLoaded(), "SignUp page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test]
    public void TestSignUp()
    {
        try
        {
            BrowserEnvironment.LoadApplication(URL);
            var signupPage = Page.Login.SubmitEmailForm("sample@sample.com");
            Assert.IsTrue(signupPage.IsLoaded(), "SignUp page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }

    [OneTimeTearDown]
    public void CleanUp()
    {
        BrowserEnvironment.CloseDriver();
    }
}
