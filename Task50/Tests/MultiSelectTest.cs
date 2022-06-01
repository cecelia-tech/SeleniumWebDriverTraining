namespace Tests;

[TestFixture]
public class MultiSelectTest : TestBaseClass
{
    const string URL = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

    [Test]
    public void MultiselectTest()
    {
        _driver.Url = URL;


    }
}
