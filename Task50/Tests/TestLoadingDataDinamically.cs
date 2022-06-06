namespace Tests;

internal class TestLoadingDataDinamically : TestBaseClass
{
    [Test]
    public void TestIsNewUserDisplayed()
    {
        LoadingDataDinamically loadingDataDinamically = new LoadingDataDinamically(_driver);

        Assert.IsTrue(loadingDataDinamically.IsNewUserDisplayed(), "User is not visable on the screen");
    }
}
