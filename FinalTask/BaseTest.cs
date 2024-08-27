using Aquality.Selenium.Browsers;
using NUnit.Framework;
using UnionReporting.Utils;

namespace UnionReporting;

public class BaseTest
{
    [TearDown]
    public void CloseBrowser()
    {
        if (AqualityServices.IsBrowserStarted)
        {
            DriverUtil.Quit();
        }
    }
}
