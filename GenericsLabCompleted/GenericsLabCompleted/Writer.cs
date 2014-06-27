using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsLabCompleted
{
  class Writer: IComparable<Writer>
  {
    public string Name;
    public string HomeState;

    public Writer()
    {

    }

    public Writer(string Name, string HomeState)
    {
      this.Name = Name;
      this.HomeState = HomeState;
    }

    public override string ToString()
    {
      return string.Format("{0} is from {1}.", 
        this.Name, this.HomeState);
    }

    #region IComparable<Writer> Members

    public int CompareTo(Writer other)
    {
      return this.Name.CompareTo(other.Name);
    }

    #endregion
  }
}
