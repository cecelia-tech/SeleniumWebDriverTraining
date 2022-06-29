namespace TestAutomationPractice;

[TestFixture]
[AllureNUnit]
public class LogInTest : TestBaseClass
{
    [Test]
    public void TestLogIn()
    {
        try
        {
            var loginPage = Page.Login.LoadPage();
            var userHomePage = loginPage.FillLogInDetails(DataFromFile.GetElementValue("email"), DataFromFile.GetElementValue("password"));
            Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}
