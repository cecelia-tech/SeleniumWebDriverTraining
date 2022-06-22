using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

internal class LoginPage : BaseClass
{
    private const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

    [FindsBy(How = How.Id, Using = "email_create")]
    private IWebElement emailInput;
    [FindsBy(How = How.Id, Using = "SubmitCreate")]
    private IWebElement crteateAccountButton;
    
    private By errorMessage = By.Id("create_account_error");

    public LoginPage(IWebDriver driver) : base(driver)
    {
        Load();
    }

    private void Load()
    {
        _driver.Url = URL;
    }

    internal bool IsLoaded()
    {
        try
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("create-account_form"))).Displayed;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }

    internal SignUpPage FillEmail(string email)
    {
        SetEmail(email);
        ClickCreateAccountButton();

        if (!IsEmailCorrect())
        {
            throw new ArgumentException("Wrong email format or this email already exists");
        }

        return new SignUpPage(_driver);
    }

    private void SetEmail(string email)
    {
        emailInput.Clear();
        emailInput.SendKeys(email);
    }

    private void ClickCreateAccountButton()
    {
        crteateAccountButton.Click();
    }

    private bool IsEmailCorrect()
    {
        return new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(errorMessage));
    }
}
