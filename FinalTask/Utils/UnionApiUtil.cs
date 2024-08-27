using RestSharp;
using System.Collections.Generic;
using UnionReporting.Models;
using UnionReporting.ProjectConstants;

namespace UnionReporting.Utils;

public static class UnionApiUtil
{
    public static string GetToken(string variant)
    {
        Dictionary<string, string> queryParams = new()
            {
                {ParameterNames.Variant, variant}
            };
        RestResponse tokenResponse = ApiUtil.PostRequest(Endpoints.TokenGet, queryParams);
        return tokenResponse.Content;
    }

    public static List<UnionTest> GetJsonTests(string projectId)
    {
        Dictionary<string, string> queryParams = new()
            {
                {ParameterNames.ProjectId, projectId}
            };
        RestResponse jsonTestsResponse = ApiUtil.PostRequest(Endpoints.TestGetJson, queryParams);
        return JsonUtil.ParseList<UnionTest>(jsonTestsResponse.Content);
    }

    public static string TestPut(TestRecord testRecord)
    {
        Dictionary<string, string> queryParams = new()
            {
                {ParameterNames.SID, testRecord.SID},
                {ParameterNames.ProjectName, testRecord.ProjectName},
                {ParameterNames.TestName, testRecord.TestName},
                {ParameterNames.MethodName, testRecord.MethodName},
                {ParameterNames.Env, testRecord.Env},
                {ParameterNames.Browser, testRecord.Browser}
            };
        RestResponse testPutResponse = ApiUtil.PostRequest(Endpoints.TestPut, queryParams);
        return testPutResponse.Content;
    }

    public static void TestPutLog(int testId, string content)
    {
        Dictionary<string, string> queryParams = new()
        {
            {ParameterNames.TestId, testId.ToString()},
            {ParameterNames.Content, content}
        };
        _ = ApiUtil.PostRequest(Endpoints.TestPutLog, queryParams);
    }

    public static void TestPutAttachment(int testId, string content, string contentType)
    {
        Dictionary<string, string> queryParams = new()
        {
            {ParameterNames.TestId, testId.ToString()},
            {ParameterNames.Content, content},
            {ParameterNames.ContentType, contentType},
        };
        _ = ApiUtil.PostRequest(Endpoints.TestPutAttachment, queryParams);
    }
}
