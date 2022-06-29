namespace TestAutomationPractice;

[TestFixture]
[AllureNUnit]
public class AddToCustomWishlistTest : TestBaseClass
{
    private const string MY_WISHLIST_NAME = "DreamPurchases";

    [Test, Order(1)]
    public void TestUserLogIn()
    {
        try
        {
            var logInPage = Page.Login.LoadPage();
            var userHomePage = logInPage.FillLogInDetails(DataFromFile.GetElementValue("email"), DataFromFile.GetElementValue("password"));
            Assert.IsTrue(userHomePage.IsPageLoaded(), "User homepage was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(2)]
    public void TestWishlistPageLoaded()
    {
        try
        {
            var wishlists = Page.UserHome.ClickWishlist();
            Assert.IsTrue(wishlists.IsPageLoaded(), "wishlists page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(3)]
    public void TestCreateCustomWishlist()
    {
        try
        {
            var wishlists = Page.WishLists.CreateMyWishList(MY_WISHLIST_NAME);
            Assert.IsTrue(wishlists.DoesCustomWishlistWasCreated(MY_WISHLIST_NAME), $"Wishlist with name {MY_WISHLIST_NAME} was not created");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(4)]
    public void TestProductPageLoaded()
    {
        try
        {
            var productPage = Page.WishLists.ClickProduct();
            Assert.IsTrue(productPage.IsPageLoaded(), "Product page was not loaded");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }

    [Test, Order(5)]
    public void TestAddToCustomWishList()
    {
        try
        {
            var productPage = Page.ProductPage.AddToWishList();
            var wishlists = productPage.GoToUserHomePage().ClickWishlist();
            Assert.IsTrue(wishlists.CheckProductAddedToCustomWishList(MY_WISHLIST_NAME), "Product was not added to the wishlist");
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
}
