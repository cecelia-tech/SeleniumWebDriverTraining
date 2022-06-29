namespace TestAutomationPractice;

[AllureNUnit]
[TestFixture]
internal class CreateAccountTest : TestBaseClass
{
    [Test]
    public void TestCreateAcount()
    {
        try
        {
            var loginPage = Page.Login.LoadPage();
            var signupPage = loginPage.SubmitEmailForm("p@gh2.com");
            Assert.IsTrue(signupPage.IsPageLoaded(), "SignUp page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, TestCaseSource(typeof(DataFromFile2), nameof(DataFromFile2.RegisterFormData))]
    public void TestSignUp(string firstName, string lastName, string email, string password,
        string address, string city, string state, string zipCode, string country, string mobile_phone, string alias)
    {
        try
        {
            var userHomePage = Page.SignUp.FillRegistrationForm(firstName, lastName, email, password,
        address, city, state, zipCode, country, mobile_phone, alias);
            Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}
