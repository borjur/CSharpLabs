using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      AddOrders();

      Console.WriteLine();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

    private static void AddOrders()
    {
      CorporateOrder order1 = new CorporateOrder();
      order1.OrderID = 1000;
      order1.CustomerID = "Bigge";
      order1.OrderDate = DateTime.Today;
      order1.Units = 1000;
      order1.UnitCost = 100;
      order1.TotalCost = order1.UnitCost * order1.Units;
      order1.SalesRep = "Ed";
      order1.Terms = "Net 60";
      order1.PromisedDate = DateTime.Today.AddDays(7);

      order1.SaveOrder();
      order1.SaveOrder("short");

      Console.WriteLine(
        "Customer {0} placed order {1} on {2:d}",
        order1.CustomerID, order1.OrderID, order1.OrderDate);
      Console.WriteLine(
        "The customer has been promised delivery by {0:d}",
        order1.PromisedDate);
      Console.WriteLine(
        "{0} units were ordered at {1:C} each",
        order1.Units, Convert.ToInt32(order1.UnitCost));
      Console.WriteLine(
        "The total cost of this order is {0:C}",
        order1.TotalCost);
      Console.WriteLine(
        "The terms for this order are {0}", order1.Terms);
      Console.WriteLine(
        "{0} is the sales rep for this order", order1.SalesRep);

      Console.WriteLine();
      order1.Shipper = "LightningFast";
      order1.Priority = "High";
      order1.MarkAsDelivered(
        order1.OrderID, order1.Shipper, 
        order1.Priority, DateTime.Today.AddDays(2));
      if (order1.IsDelivered())
      {
        Console.WriteLine(
          "Order {0} was delivered on {1:d}", 
          order1.OrderID, order1.DeliveryDate);
        Console.WriteLine(
          "Order was delivered {0} priority by {1}", 
          order1.Priority, order1.Shipper);
      }
      else
      {
        Console.WriteLine(
          "Order {0} was not delivered", order1.OrderID);
      } 
            
      IndividualOrder order2 = new IndividualOrder();
      order2.OrderID = 1000;
      order2.CustomerID = "Smith";
      order2.OrderDate = DateTime.Today;
      order2.Units = 100;
      order2.UnitCost = 10;
      order2.TotalCost = order2.UnitCost * order2.Units;
      order2.PaymentType = "Credit";
      order2.Email = "smith@somewhere.com";

      Console.WriteLine();
      Console.WriteLine(
        "Customer {0} placed order {1} on {2:d}",
        order2.CustomerID, order2.OrderID, order2.OrderDate);
      Console.WriteLine(
        "{0} units were ordered at {1:C} each",
        order2.Units, Convert.ToInt32(order2.UnitCost));
      Console.WriteLine(
        "The total cost of this order is {0:C}",
        order2.TotalCost);
      Console.WriteLine(
        "This order will be paid by {0}",
        order2.PaymentType);
      Console.WriteLine(
        "The customer can be reached at {0}",
        order2.Email);
    }

  }
}
