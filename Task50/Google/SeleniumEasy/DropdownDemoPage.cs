using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task50Pages;

internal class DropdownDemoPage : BaseClass
{
    const string URL = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
    const string MULTISELECT_LOCATOR = "multi-select";
    

    public DropdownDemoPage(IWebDriver driver) : base(driver)
    {
        _driver.Url = URL;
    }

    public int SelectMultipleOptions()
    {
        SelectElement multiSelect = new SelectElement(GetElementById(MULTISELECT_LOCATOR));

        if (multiSelect.IsMultiple)
        {
            multiSelect.SelectByIndex(0);
            multiSelect.SelectByIndex(1);
            multiSelect.SelectByIndex(2);
        }

        IList<IWebElement> options = new List<IWebElement>();

        foreach (var option in multiSelect.Options)
        {
            if (option.Selected)
            {
                options.Add(option);
            }
        }

        return options.Count;
    }
}
