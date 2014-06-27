using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsLabCompleted
{
  class House: IComparable<House>
  {
    public string Description;
    public int Size;

    public House()
    {

    }

    public House(string Description, int Size)
    {
      this.Description = Description;
      this.Size = Size;
    }

    public override string ToString()
    {
      return string.Format("{0} is {1:C} square feet.", 
        this.Description, this.Size);
    } 

    #region IComparable<House> Members

    public int CompareTo(House other)
    {
      return this.Size.CompareTo(other.Size);
    }

    #endregion
  }
}
