namespace Tests;

[TestFixture]
internal class TestTableSortAndSearch : TestBaseClass
{
    [Test]
    public void TestSelectData()
    {
        TableSortAndSearch tableSortAndSearch = new TableSortAndSearch(_driver);

        Assert.IsNotNull(tableSortAndSearch.SelectData(60, 200000));
    }
}
