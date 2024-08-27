using System.Collections.Generic;
using System.Text.Json;

namespace UnionReporting.Utils;

public static class JsonUtil
{
    public static T ParseObj<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static List<T> ParseList<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<List<T>>(jsonString);
    }

    public static T ParseObjFromFile<T>(string pathToFile)
    {
        return ParseObj<T>(FileUtil.ReadFromFile(pathToFile));
    }
}
