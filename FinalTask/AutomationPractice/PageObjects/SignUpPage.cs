using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using System.Xml.Linq;

namespace AutomationPractice;

internal class SignUpPage : BaseClass
{
    private By signUpForm = By.Id("account-creation_form");
    private IWebDriver _driver;
    [FindsBy(How = How.Id, Using = "customer_firstname")]
    private IWebElement personalInfoFirstNameInputLocator;
    [FindsBy(How = How.Id, Using = "customer_lastname")]
    private IWebElement personalInfoLastNameInputLocator;
    [FindsBy(How = How.Id, Using = "passwd")]
    private IWebElement passwordInputLocator;
    [FindsBy(How = How.CssSelector, Using = "input[id='firstname']")]
    private IWebElement addressFirstNameInputLocator;
    [FindsBy(How = How.CssSelector, Using = "input[id='lastname']")]
    private IWebElement addressLastNameInputLocator;
    [FindsBy(How = How.Id, Using = "address1")]
    private IWebElement addressInputLocator;
    [FindsBy(How = How.Id, Using = "city")]
    private IWebElement cityInputLocator;
    [FindsBy(How = How.Id, Using = "id_state")]
    private IWebElement state;
    [FindsBy(How = How.Id, Using = "id_country")]
    private IWebElement country;
    [FindsBy(How = How.Id, Using = "postcode")]
    private IWebElement zipCode;
    [FindsBy(How = How.Id, Using = "phone_mobile")]
    private IWebElement mobileNumber;
    [FindsBy(How = How.Id, Using = "alias")]
    private IWebElement alias;
    [FindsBy(How = How.Id, Using = "submitAccount")]
    private IWebElement registerButton;

    public SignUpPage(IWebDriver driver)
    {
    }

    internal bool IsLoaded()
    {
        try
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(signUpForm)).Displayed;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }

    internal UserHomePage FillRegistrationForm(string firstName, string lastName, string email, string password,
        string address, string city, string state, string zipCode, string country, string mobile_phone, string alias)
    {
        SetInputValue(personalInfoFirstNameInputLocator, firstName);
        SetInputValue(personalInfoLastNameInputLocator, lastName);
        SetInputValue(passwordInputLocator, password);
        SetInputValue(addressFirstNameInputLocator, firstName);
        SetInputValue(addressLastNameInputLocator, lastName);
        SetInputValue(addressInputLocator, address);
        SetInputValue(cityInputLocator, city);
        SelectDropdownElementByValue(this.state, state);
        SetInputValue(this.zipCode, zipCode);
        SelectDropdownElementByValue(this.country, country);
        SetInputValue(mobileNumber, mobile_phone);
        SetInputValue(this.alias, alias);
        ClickElement(registerButton);

        return new UserHomePage(_driver);
    }

    
    private IEnumerable RegisterFormData
    {
        get { return GetRegisterFormData(); }
    }

    private IEnumerable GetRegisterFormData()
    {
        var doc = XDocument.Load("RegisterFormData.xml");

        return from vars in doc.Descendants("vars")
               let firstName = vars?.Attribute("first_name")?.Value
               let lastName = vars?.Attribute("last_name")?.Value
               let email = vars?.Attribute("email")?.Value
               let password = vars?.Attribute("password")?.Value
               let address = vars?.Attribute("address")?.Value
               let city = vars?.Attribute("city")?.Value
               let state = vars?.Attribute("state")?.Value
               let zipCode = vars?.Attribute("zip_code")?.Value
               let country = vars?.Attribute("country")?.Value
               let mobile_phone = vars?.Attribute("mobile_phone")?.Value
               select new object []
               {
                   firstName,
                   lastName,
                   email,
                   password,
                   address,
                   city,
                   state,
                   zipCode,
                   country,
                   mobile_phone
               };
    }


}
