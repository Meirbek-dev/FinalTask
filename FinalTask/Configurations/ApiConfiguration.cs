namespace UnionReporting.Configurations;

public static class ApiConfiguration
{
    public static string ApiUrl => Environment.CurrentEnvironment.GetValue<string>(".apiUrl");
}
