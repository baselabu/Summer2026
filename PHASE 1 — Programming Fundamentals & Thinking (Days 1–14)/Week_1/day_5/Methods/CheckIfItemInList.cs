using System;

namespace day_4.Methods;

public class CheckIfItemInList
{
    public static bool CheckItem(List<string> ItemList, string TargetItem)
    {
        if (ItemList.Contains(TargetItem))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
