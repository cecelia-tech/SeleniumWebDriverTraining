using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task50Pages.SeleniumEasy;

internal class TableSortAndSearch : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
    const string SELECT_DROPDOWN_LOCATOR = "select[name = example_length]";
    const string NEXT_BUTTON_LOCATOR = "example_next";
    const string TABLE_LOCATOR = "example";


    public TableSortAndSearch(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    public List<Person> SelectData(int age, int salary)
    {
        List<Person> selectedPeople = new List<Person>();

        try
        {
            SelectElement element = new SelectElement(GetElementByCSS(SELECT_DROPDOWN_LOCATOR));
            element.SelectByValue("10");

            while (GetElementById(NEXT_BUTTON_LOCATOR).Enabled)
            {
                var table = GetElementById(TABLE_LOCATOR);

                List<IWebElement> rows = new List<IWebElement>(table.FindElements(By.CssSelector("tbody > tr")));

                foreach (var row in rows)
                {
                    List<IWebElement> rowElements = new List<IWebElement>(row.FindElements(By.TagName("td")));

                    if (int.Parse(rowElements[3].Text) > age &&
                        int.Parse(rowElements[5].GetAttribute("data-order")) <= salary)
                    {
                        selectedPeople.Add(new Person(rowElements[0].GetAttribute("data-search"), rowElements[1].Text, rowElements[2].Text));
                    }
                }

                if (GetElementById(NEXT_BUTTON_LOCATOR).GetAttribute("class").Contains("disabled"))
                {
                    break;
                }

                GetElementById(NEXT_BUTTON_LOCATOR).Click();
            }

            return selectedPeople;
        }
        catch (NoSuchElementException)
        {
            return selectedPeople;
        }
    }
}
