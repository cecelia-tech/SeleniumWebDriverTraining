using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace AutomationPractice;

public class SignUpPage : BaseClass
{
    private By signUpForm = By.Id("account-creation_form");
    
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

    public SignUpPage()
    {
    }

    internal bool IsLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("account-creation_form"))).Displayed;
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
        SelectDropdownElementByText(this.state, state);
        SetInputValue(this.zipCode, zipCode);
        SelectDropdownElementByText(this.country, country);
        SetInputValue(mobileNumber, mobile_phone);
        SetInputValue(this.alias, alias);
        ClickElement(registerButton);

        return Page.UserHomePage;
    }

    
    
    //return from addressDetails in doc.Descendants("address")
    //       let firstName = addressDetails?.Element("first_name")?.Value
    //       let lastName = addressDetails?.Element("last_name")?.Value
    //       let email = addressDetails?.Element("email")?.Value
    //       let password = addressDetails?.Element("password")?.Value
    //       let address = addressDetails?.Element("address")?.Value
    //       let city = addressDetails?.Element("city")?.Value
    //       let state = addressDetails?.Element("state")?.Value
    //       let zipCode = addressDetails?.Element("zip_code")?.Value
    //       let country = addressDetails?.Element("country")?.Value
    //       let mobile_phone = addressDetails?.Element("mobile_phone")?.Value
    //       let alias = addressDetails?.Element("alias")?.Value
    //select  new object [] 
    //{
    //    firstName,
    //    lastName,
    //    email,
    //    password,
    //    address,
    //    city,
    //    state,
    //    zipCode,
    //    country,
    //    mobile_phone,
    //    alias
    //};



}
