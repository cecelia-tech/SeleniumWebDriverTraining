namespace Tests;

[TestFixture]
internal class TestTableSortAndSearch : TestBaseClass
{
    [Test]
    public void TestSelectData()
    {
        TableSortAndSearch tableSortAndSearch = new TableSortAndSearch(_driver);

        Assert.AreNotEqual(tableSortAndSearch.SelectData(60, 200000).Count, 0, "There are no poeple with specified criteria");
    }
}
