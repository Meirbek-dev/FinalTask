namespace UnionReporting.Configurations;

public static class Configuration
{
    public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>(".startUrl");
}
