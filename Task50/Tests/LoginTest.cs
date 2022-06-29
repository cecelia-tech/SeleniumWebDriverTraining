namespace Tests;

[TestFixture]
public class Tests : TestBaseClass
{
    [TestCase("jcecelia72@gmail.com", "KadIrKas_Bebutu63!")]
    [TestCase("ceceliajohnson777@gmail.com", "Ain3:_AiEm4HccC")]
    public void Test1(string username, string password)
    {
        HomePage homePage = new HomePage(_driver);
        var loginPage = homePage.NavigateToLogin();

        var homePageAfterLogin = loginPage.Login(username, password);

        //Explicit wait
        Thread.Sleep(1000);

        Assert.IsTrue(homePageAfterLogin.CheckAccountImage(), "Account image was not found");
    }
}
