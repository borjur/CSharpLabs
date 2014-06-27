using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsLabCompleted
{
  class Helpers
  {
    public static bool IsInCA(Writer author)
    {
      if (author.HomeState == "CA")
      { return true; }
      else
      { return false; }
    }

    public static bool IsInFL(Writer author)
    {
      if (author.HomeState == "FL")
      { return true; }
      else
      { return false; }
    }

    public static bool IsInWA(Writer author)
    {
      if (author.HomeState == "WA")
      { return true; }
      else
      { return false; }
    }

    public static int Compare<itemType>
      (itemType class1, itemType class2)
      where itemType : IComparable<itemType>
    {
      return class1.CompareTo(class2);
    }
  }
}
