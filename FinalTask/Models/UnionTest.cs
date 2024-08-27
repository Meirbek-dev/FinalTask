using System;
using System.Text.Json.Serialization;
using UnionReporting.Forms;

namespace UnionReporting.Models;

public class UnionTest
{
    [JsonPropertyName("duration")]
    public string Duration { get; set; }

    [JsonPropertyName("method")]
    public string Method { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("startTime")]
    public string StartTime { get; set; }

    [JsonPropertyName("endTime")]
    public string EndTime { get; set; }

    [JsonPropertyName("status")]
    public string Result { get; set; }

    public UnionTest()
    {
    }

    public UnionTest(TestRow testRow)
    {
        Duration = testRow.GetTestDuration();
        Method = testRow.GetTestMethod();
        Name = testRow.GetTestName();
        StartTime = testRow.GetTestStartTime();
        EndTime = testRow.GetTestEndTime();
        Result = testRow.GetTestResult();
    }

    protected bool Equals(UnionTest other)
    {
        return Duration == other.Duration && Method == other.Method && Name == other.Name && StartTime == other.StartTime && (EndTime ?? string.Empty) == (other.EndTime ?? string.Empty) && string.Equals(Result, other.Result, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object obj)
    {
        return obj is not null && (ReferenceEquals(this, obj) || (obj.GetType() == GetType() && Equals((UnionTest)obj)));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Duration, Method, Name, StartTime, EndTime, Result);
    }
}
