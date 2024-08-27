using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System.Reflection;

namespace UnionReporting.Configurations;

internal static class Environment
{
    public static ISettingsFile CurrentEnvironment
    {
        get
        {
            string envName = AqualityServices.Get<ISettingsFile>().GetValue<string>("environment");
            string pathToConfigFile = $"Resources.Environment.{envName}.config.json";
            return new JsonSettingsFile(pathToConfigFile, Assembly.GetCallingAssembly());
        }
    }
}
