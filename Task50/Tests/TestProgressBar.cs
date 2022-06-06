namespace Tests;

internal class TestProgressBar : TestBaseClass
{
    [Test]
    public void TestRestartPage()
    {
        ProgressBarPage progressBarPage = new ProgressBarPage(_driver);

        Assert.IsNotNull(progressBarPage.RestartPage(), "The page was not refreshed");
    }
}
