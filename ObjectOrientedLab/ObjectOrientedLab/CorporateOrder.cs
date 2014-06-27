using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedLab
{
  class CorporateOrder: Order
  {
    private string _SalesRep;
    private string _Terms;
    private DateTime _PromisedDate =
      DateTime.Today.AddDays(14);
    public string SalesRep
    {
      get
      { return _SalesRep; }
      set
      { _SalesRep = value; }
    }
    public string Terms
    {
      get
      { return _Terms; }
      set
      { _Terms = value; }
    }
    public DateTime PromisedDate
    {
      get
      { return _PromisedDate; }
      set
      { _PromisedDate = value; }
    }
    public CorporateOrder()
    {
    }

  }
}
