using System.Collections.Generic;

public static class Indexer
{
    /// <summary>
    /// Returns all occurences of a string within another string.
    /// </summary>
    /// <param name="str">the string to be searched.</param>
    /// <param name="searchstring">the search key.</param>
    /// <returns>A collection of integers that contains all occurences of the search string in the string.</returns>
    public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
    {
        int minIndex = str.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
        }
    }
}
