using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedLabCompleted
{
  class IndividualOrder : Order
  {
    private string _PaymentType;
    private string _Email = string.Empty;
    private decimal _TotalCost;

    public IndividualOrder()
    {
    }

    public IndividualOrder(
      int orderID, string customerID,
      DateTime orderDate, int units,
      decimal unitCost, string paymentType,
      string email)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.OrderDate = orderDate;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
      this.PaymentType = paymentType;
      this.Email = email;
    }

    public IndividualOrder(
      int orderID, string customerID,
      int units, decimal unitCost,
      string paymentType, string email)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
      this.PaymentType = paymentType;
      this.Email = email;
    }

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

    public override decimal TotalCost
    {
      get
      { return _TotalCost; }
      set
      {
        if (this.OrderDate.DayOfWeek == DayOfWeek.Friday)
        {
          _TotalCost =
            Convert.ToDecimal(0.8 * this.Units) * 
            this.UnitCost;
        }
        else
        {
          _TotalCost = this.Units * this.UnitCost;
        }
      }
    }

  }
}
