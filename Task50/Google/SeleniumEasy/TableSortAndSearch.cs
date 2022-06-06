using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task50Pages.SeleniumEasy;

internal class TableSortAndSearch : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
    const string SELECT_DROPDOWN_LOCATOR = "select[name = example_length]";
    const string TABLE_ROW_LOCATOR = "//tbody/tr";
    const string NEXT_BUTTON_LOCATOR = "example_next";
    const string TABLE_ROW_NAME_LOCATOR = "/td[1]";
    const string TABLE_ROW_POSITION_LOCATOR = "/td[2]";
    const string TABLE_ROW_OFFICE_LOCATOR = "/td[3]";
    //const string TABLE_ROW_AGE_LOCATOR = "#example tbody > tr > td:nth-child(4)";
    const string TABLE_ROW_AGE_LOCATOR = "//td[4]";
    const string TABLE_ROW_SALARY_LOCATOR = "/td[6]";
    const string TABLE_LOCATOR = "example";


    public TableSortAndSearch(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    public List<Person>? SelectData(int age, int salary)
    {
        try
        {
            SelectElement element = new SelectElement(GetElementByCSS(SELECT_DROPDOWN_LOCATOR));
            element.SelectByValue("10");

            var table = GetElementById(TABLE_LOCATOR);
            List<IWebElement> lstTrElem = new List<IWebElement>(table.FindElements(By.CssSelector("tbody > tr")));

            foreach (var row in lstTrElem)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(row.FindElements(By.TagName("td")));

                foreach (var item in lstTdElem)
                {
                    var s = item.Text;
                }

            }

            //List<IWebElement> allRows = _driver.FindElements(By.XPath(TABLE_ROW_LOCATOR)).ToList();
            List<Person> selectedPeople = new List<Person>();
            //i for det 10 ir im kiekviena row is naujo su td[number till 10]
            while (GetElementById(NEXT_BUTTON_LOCATOR).Enabled)
            {
                //var allRows = _driver.FindElements(By.XPath(TABLE_ROW_LOCATOR));
                
                for (int i = 1; i <= 10; i++)
                {
                    var row = GetElementByXPath($"//tbody/tr[{i}]");
                    var rowElements =row.FindElement(By.XPath(TABLE_ROW_AGE_LOCATOR)); 
                }
                /*foreach (var row in allRows.ToList())
                {
                    if (int.Parse(row.FindElement(By.XPath(TABLE_ROW_AGE_LOCATOR)).Text) > age &&
                        int.Parse(row.FindElement(By.XPath(TABLE_ROW_SALARY_LOCATOR)).GetAttribute("data-order")) <= salary)
                    {
                        selectedPeople.Add(new Person(row.FindElement(By.XPath(TABLE_ROW_NAME_LOCATOR)).GetAttribute("data-search"),
                    row.FindElement(By.XPath(TABLE_ROW_POSITION_LOCATOR)).Text,
                    row.FindElement(By.XPath(TABLE_ROW_OFFICE_LOCATOR)).Text));
                    }
                }*/
                /*var dataToReturn = allRows
                    .Where(row => int.Parse(row.FindElement(By.CssSelector(TABLE_ROW_AGE_LOCATOR)).Text) > age
                    && int.Parse(row.FindElement(By.XPath(TABLE_ROW_SALARY_LOCATOR)).GetAttribute("data-order")) <= salary)
                    .Select(row => new Person(row.FindElement(By.XPath(TABLE_ROW_NAME_LOCATOR)).GetAttribute("data-search"),
                    row.FindElement(By.XPath(TABLE_ROW_POSITION_LOCATOR)).Text,
                    row.FindElement(By.XPath(TABLE_ROW_OFFICE_LOCATOR)).Text));

                selectedPeople.AddRange(dataToReturn);*/
                GetElementById(NEXT_BUTTON_LOCATOR).Click();
            }

            return selectedPeople;
        }
        catch (NoSuchElementException)
        {
            return null;
        }
        
    }
}
