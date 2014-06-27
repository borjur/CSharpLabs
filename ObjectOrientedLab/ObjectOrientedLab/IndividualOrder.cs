using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedLab
{
  class IndividualOrder : Order
  {
    private string _PaymentType;
    private string _Email = string.Empty;
    public string PaymentType
    {
      get
      { return _PaymentType; }
      set
      { _PaymentType = value; }
    }
    public string Email
    {
      get
      { return _Email; }
      set
      { _Email = value; }
    }
    public IndividualOrder()
    {
    }

  }
}
