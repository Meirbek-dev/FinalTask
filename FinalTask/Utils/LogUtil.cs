namespace UnionReporting.Utils;

public static class LogUtil
{
    private const string pathToLog = "../../../Log/log.log";

    public static string GetLog()
    {
        return FileUtil.ReadFromFile(pathToLog);
    }
}
