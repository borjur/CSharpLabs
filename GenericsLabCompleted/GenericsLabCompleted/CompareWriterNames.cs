using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsLabCompleted
{
  public class CompareWriterNames : IComparer
  {
    public int Compare(object x, object y)
    {
      Writer writer1 = ((Writer)(x));
      Writer writer2 = ((Writer)(y));
      return writer1.Name.CompareTo(writer2.Name);
    }

  }
}
