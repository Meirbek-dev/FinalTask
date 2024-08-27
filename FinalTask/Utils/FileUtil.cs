using System.IO;

namespace UnionReporting.Utils;

public static class FileUtil
{
    public static string ReadFromFile(string pathToFile)
    {
        return File.ReadAllText(Path.GetFullPath(pathToFile));
    }
}
