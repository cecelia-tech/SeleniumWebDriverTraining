﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationPractice;

public class LoginPage : BaseClass
{
    private const string URL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

    [FindsBy(How = How.Id, Using = "email_create")]
    private IWebElement createAccountEmailInput;
    [FindsBy(How = How.Id, Using = "SubmitCreate")]
    private IWebElement crteateAccountButton;
    [FindsBy(How = How.Id, Using = "email")]
    private IWebElement logInEmailInput;
    [FindsBy(How = How.Id, Using = "passwd")]
    private IWebElement logInPasswordInput;
    [FindsBy(How = How.Id, Using = "SubmitLogin")]
    private IWebElement logInButton;

    private By errorMessage = By.Id("create_account_error");

    public LoginPage()
    {
    }

    //private void Load()
    //{
    //    _driver.Url = URL;
    //}

    internal bool IsLoaded()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("create-account_form"))).Displayed;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }

    internal SignUpPage SubmitEmailForm(string email)
    {
        SetEmail(email);
        ClickCreateAccountButton();

        if (IsEmailIncorrect())
        {
            throw new ArgumentException("Wrong email format or this email already exists");
        }

        return Page.SignUp;
    }

    private void SetEmail(string email)
    {
        createAccountEmailInput.Clear();
        createAccountEmailInput.SendKeys(email);
    }

    private void ClickCreateAccountButton()
    {
        crteateAccountButton.Click();
    }

    private bool IsEmailIncorrect()
    {
        try
        {
            return new WebDriverWait(BrowserEnvironment.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementIsVisible(By.Id("create_account_error"))).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    internal UserHomePage FillLogInDetails(string email, string password)
    {
        SetInputValue(logInEmailInput, email);
        SetInputValue(logInPasswordInput, password);
        ClickElement(logInButton);

        return Page.UserHomePage;
    }
}
