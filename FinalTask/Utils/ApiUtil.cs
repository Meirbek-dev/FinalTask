using RestSharp;
using System;
using System.Collections.Generic;
using UnionReporting.Configurations;

namespace UnionReporting.Utils;

public static class ApiUtil
{
    private static RestClient _client => GetRestClient();

    private static RestClient GetRestClient()
    {
        return new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri(ApiConfiguration.ApiUrl)
        });
    }

    public static RestResponse PostRequest(string path, Dictionary<string, string> queryParams)
    {
        RestRequest request = new(path, Method.Post);
        foreach (KeyValuePair<string, string> param in queryParams)
        {
            _ = request.AddParameter(param.Key, param.Value);
        }
        return _client.Post(request);
    }
}
