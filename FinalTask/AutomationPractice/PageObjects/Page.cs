using SeleniumExtras.PageObjects;

namespace AutomationPractice;

internal static class Page
{
    private static T GetPage<T>() where T : new()
    {
        var page = new T();
        PageFactory.InitElements(Environment.Driver, page);
        return page;
    }

    public static UserHomePage UserHome
    {
        get { return GetPage<UserHomePage>(); }
    }

    public static LoginPage Login
    {
        get { return GetPage<LoginPage>(); }
    }
}
