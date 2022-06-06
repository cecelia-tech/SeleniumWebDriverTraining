namespace Tests;

[TestFixture]
public class PopUpAlertsTest : TestBaseClass
{
    const string TEXT_FOR_PROMPT_BOX = "Test";
    PopUpAlarts popUpAlerts;

    //2 tests for Confirm box
    [Test]
    public void TestDeclineConfirmBox()
    {
        popUpAlerts = new PopUpAlarts(_driver);

        Assert.IsTrue(popUpAlerts.DeclineConfirmBox().Contains("Cancel"), "Text doesn't contain expected value");
    }

    [Test]
    public void TestAcceptConfirmBox()
    {
        popUpAlerts = new PopUpAlarts(_driver);

        Assert.IsTrue(popUpAlerts.AcceptConfirmBox().Contains("OK"), "Text doesn't contain expected value");
    }

    //1 test for Prompt box alert
    [Test]
    public void TestAcceptPromptBoxAlert()
    {
        popUpAlerts = new PopUpAlarts(_driver);

        var text = popUpAlerts.AcceptPromptBoxAlert(TEXT_FOR_PROMPT_BOX);

        Assert.IsTrue(text.Contains(TEXT_FOR_PROMPT_BOX), "Value doesn't contain expected text");
    }
}
