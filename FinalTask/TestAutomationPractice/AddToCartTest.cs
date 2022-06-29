namespace TestAutomationPractice;

[AllureNUnit]
[TestFixture]
public class AddToCartTest : TestBaseClass
{
    [Test, Order(1)]
    public void TestUserLogIn()
    {
        try
        {
            var logInPage = Page.Login.LoadPage();
            var userHomePage = logInPage.FillLogInDetails(DataFromFile2.GetElementValue("email"), DataFromFile2.GetElementValue("password"));
            Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(2)]
    public void TestDressesPageLoad()
    {
        try
        {
            var dressesPage = Page.UserHome.ClickDressesOption();
            Assert.IsTrue(dressesPage.IsPageLoaded(), "Dresses page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(3)]
    public void TestDressesAddedToTheCart()
    {
        var expectedNumberOfItemsInTheCart = 3;
        try
        {
            var dressesPage = Page.DressesPage.AddThreeDressesToTheCart();
            var cartPage = dressesPage.GoToCart();
            Assert.AreEqual(cartPage.CountProductsInTheCart(), expectedNumberOfItemsInTheCart, "Cart page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(3)]
    public void TestTotalOfTheCart()
    {
        try
        {
            var expectedCartTotal = 107.97;

            Assert.AreEqual(expectedCartTotal, Page.CartPage.GetCartTotal(), "Cart total doesn't match");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}
