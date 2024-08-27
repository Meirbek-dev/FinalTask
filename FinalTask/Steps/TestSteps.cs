using System.Collections.Generic;
using System.Linq;
using UnionReporting.Forms.Pages;
using UnionReporting.Models;
using UnionReporting.Utils;

namespace UnionReporting.Steps;

public static class TestSteps
{
    public static List<UnionTest> GetApiTestsOrderedByStartTime(string nexageProjectId, int numOfTests)
    {
        List<UnionTest> apiTests = UnionApiUtil.GetJsonTests(nexageProjectId);
        List<UnionTest> apiTestsOrderedByStartTime = apiTests.OrderBy(test => test.StartTime).Reverse().ToList();
        return apiTestsOrderedByStartTime.Take(numOfTests).ToList();
    }

    public static int PutTest(TestData testData)
    {
        TestRecord currentTestRecord = new(testData);
        int testId = int.Parse(UnionApiUtil.TestPut(currentTestRecord));
        string logContent = LogUtil.GetLog();
        UnionApiUtil.TestPutLog(testId, logContent);
        _ = ProjectPage.TestRowIsDisplayed(testId);
        string screenshot = DriverUtil.GetScreenshot().AsBase64EncodedString;
        UnionApiUtil.TestPutAttachment(testId, screenshot, "image/png");
        return testId;
    }
}
