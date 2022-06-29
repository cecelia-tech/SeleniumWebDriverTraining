namespace Tests;

[TestFixture]
public class MultiSelectTest : TestBaseClass
{
    const string URL = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

    [Test]
    public void MultiselectTest()
    {
        _driver.Url = URL;

        int expectedResult = 3;

        DropdownDemoPage dropdownDemoPage = new DropdownDemoPage(_driver);

        Assert.AreEqual(expectedResult, dropdownDemoPage.SelectMultipleOptions(), $"{dropdownDemoPage.SelectMultipleOptions()} options selected instead of {expectedResult}");
    }
}
