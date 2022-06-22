using SeleniumExtras.PageObjects;

namespace AutomationPractice;

internal static class Page
{
    private static T GetPage<T>() where T : new()
    {
        var page = new T();
        PageFactory.InitElements(BrowserFactory.Driver, page);
        return page;
    }

    public static LoginPage Home
    {
        get { return GetPage<LoginPage>(); }
    }

    public static LoginPage Login
    {
        get { return GetPage<LoginPage>(); }
    }
}
