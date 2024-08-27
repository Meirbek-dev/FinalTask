using System.Text.Json.Serialization;

namespace UnionReporting.Utils;

public class TestData
{
    private const string _testDataPath = "Resources/test_data.json";

    public string SID { get; set; }
    public string Browser { get; set; }
    public string ProjectName { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("variant")]
    public string Variant { get; set; }

    [JsonPropertyName("testProjectName")]
    public string TestProjectName { get; set; }

    [JsonPropertyName("currentTestName")]
    public string TestName { get; set; }

    [JsonPropertyName("currentMethodName")]
    public string MethodName { get; set; }

    [JsonPropertyName("currentEnv")]
    public string Env { get; set; }

    public static TestData GetTestData()
    {
        return JsonUtil.ParseObjFromFile<TestData>(_testDataPath);
    }
}
