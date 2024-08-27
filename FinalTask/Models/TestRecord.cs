using System.Text.Json.Serialization;
using UnionReporting.Utils;

namespace UnionReporting.Models;

public class TestRecord
{
    [JsonPropertyName("SID")]
    public string SID { get; set; }

    [JsonPropertyName("projectName")]
    public string ProjectName { get; set; }

    [JsonPropertyName("testName")]
    public string TestName { get; set; }

    [JsonPropertyName("methodName")]
    public string MethodName { get; set; }

    [JsonPropertyName("env")]
    public string Env { get; set; }

    [JsonPropertyName("startTime")]
    public string StartTime { get; set; }

    [JsonPropertyName("browser")]
    public string Browser { get; set; }

    public TestRecord(TestData testData)
    {
        SID = testData.SID;
        ProjectName = testData.ProjectName;
        TestName = testData.TestName;
        MethodName = testData.MethodName;
        Env = testData.Env;
        Browser = testData.Browser;
    }
}
