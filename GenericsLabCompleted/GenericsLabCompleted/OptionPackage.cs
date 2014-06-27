using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsLabCompleted
{
  class OptionPackage: IComparable<OptionPackage>
  {
    public string Description;
    public decimal Cost;

    public OptionPackage()
    {

    }

    public OptionPackage(string Description, decimal Cost)
    {
      this.Description = Description;
      this.Cost = Cost;
    }

    public override string ToString()
    {
      return string.Format("{0} costs {1:C}.", 
        this.Description, this.Cost);
    } 

    #region IComparable<OptionPackage> Members

    public int CompareTo(OptionPackage other)
    {
      return this.Cost.CompareTo(other.Cost);
    }

    #endregion
  }
}
