using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionReporting.Utils;

public static class SortingUtil
{
    public static bool AreTestDatesInDescendingOrder(List<DateTime> dates)
    {
        DateTime lastDate = dates.First();
        foreach (DateTime date in dates)
        {
            if (lastDate < date)
            {
                return false;
            }
            lastDate = date;
        }
        return true;
    }
}
