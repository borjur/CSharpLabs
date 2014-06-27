using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsLabCompleted
{
  class Car : IComparable<Car>
  {
    public string Description;
    public decimal Cost;

    public Car()
    {

    }

    public Car(string Description, decimal Cost)
    {
      this.Description = Description;
      this.Cost = Cost;
    }

    public override string ToString()
    {
      return string.Format("{0} costs {1:C}.",
        this.Description, this.Cost);
    }

    private List<OptionPackage> _options = 
      new List<OptionPackage>();
    public List<OptionPackage> Options
    {
      get
      { return _options; }
      set
      { _options = value; }
    }

    #region IComparable<Car> Members

    public int CompareTo(Car other)
    {
      return this.Cost.CompareTo(other.Cost);
    }

    #endregion
  }
}
