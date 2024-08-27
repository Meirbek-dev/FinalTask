using Aquality.Selenium.Browsers;
using OpenQA.Selenium;

namespace UnionReporting.Utils;

public static class DriverUtil
{
    private static readonly Browser Browser = AqualityServices.Browser;

    public static void Refresh()
    {
        Browser.Driver.Navigate().Refresh();
    }

    public static void GoTo(string url)
    {
        Browser.GoTo(url);
    }

    public static void CloseTab()
    {
        Browser.Driver.Close();
    }

    public static Screenshot GetScreenshot()
    {
        return Browser.Driver.GetScreenshot();
    }

    public static void SwitchToWindow(string window)
    {
        _ = Browser.Driver.SwitchTo().Window(window);
    }

    public static void GoBack()
    {
        Browser.Driver.Navigate().Back();
    }

    public static string GetBrowserName()
    {
        return Browser.BrowserName.ToString();
    }

    public static string GetCurrentWindowHandle()
    {
        return Browser.Driver.CurrentWindowHandle;
    }

    public static string GetWindowHandle(int windowIndex)
    {
        return Browser.Driver.WindowHandles[windowIndex];
    }

    public static void AddCookie(string name, string value)
    {
        Browser.Driver.Manage().Cookies.AddCookie(new Cookie(name, value));
    }

    public static void Quit()
    {
        Browser.Driver.Quit();
    }
}
