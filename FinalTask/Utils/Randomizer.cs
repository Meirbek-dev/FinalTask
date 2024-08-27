using System;

namespace UnionReporting.Utils;

public static class Randomizer
{
    private static readonly Random _rnd = new();

    public static string GetText(int length = 8)
    {
        string randomStr = "";
        for (int i = 0; i < length; i++)
        {
            randomStr += (char)_rnd.Next('A', 'Z');
        }
        return randomStr;
    }
}
