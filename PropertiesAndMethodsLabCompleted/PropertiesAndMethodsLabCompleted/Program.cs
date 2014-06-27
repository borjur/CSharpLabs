using System;
using System.Collections.Generic;
using System.Text;

namespace PropertiesAndMethodsLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      AddOrder();

      Console.WriteLine();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

    static void AddOrder()
    {
      // This block of code is run in Exercise 1, step 21.
      //Order newOrder = new Order();
      //newOrder.OrderID = 1000;
      //newOrder.CustomerID = "Bigge";
      //newOrder.OrderDate = DateTime.Today;
      //newOrder.Units = 1000;
      //newOrder.UnitCost = 100;
      //newOrder.TotalCost =
      //  newOrder.UnitCost * newOrder.Units;

      // This block of code is run in Exercise 1, step 25.
      //Order newOrder = new Order(
      //  1000, "Bigge", DateTime.Today, 1000, 100);

      // This block of code is run in Exercise 1, step 29.
      //Order newOrder = new Order(1000, "Bigge", 1000, 100);

      // This block of code is run in Exercise 2, steps 9, 11 and 13.
      //Order newOrder = new Order();
      //newOrder.OrderID = 1000;
      //newOrder.CustomerID = "Bigge";
      //newOrder.OrderDate = DateTime.Today.AddDays(7);
      //newOrder.Units = 0;
      //newOrder.UnitCost = 0;
      //newOrder.TotalCost =
      //  newOrder.UnitCost * newOrder.Units;

      // This block of code is run in Exercise 2, 
      // steps 16, 21, 24, 26 and 29. 
      Order newOrder = new Order(
        1000, "Bigge", DateTime.Today, 1000, 100);

      Console.WriteLine(
        "Customer {0} placed order {1} on {2:d}",
        newOrder.CustomerID, newOrder.OrderID,
        newOrder.OrderDate);
      Console.WriteLine(
        "{0} units were ordered at {1:C} each",
        newOrder.Units, newOrder.UnitCost);
      Console.WriteLine(
        "The total cost of this order is {0:C}",
        newOrder.TotalCost);

      // This block of code is run in Exercise 3, step 6.
      Console.WriteLine();
      if (newOrder.SaveOrder() > 0)
      {
        Console.WriteLine("Order information was saved");
      }
      else
      {
        Console.WriteLine("Order information was not saved");
      }

      // This block of code is run in Exercise 3, step 14.
      newOrder.GetOrderInfo(1000);
      Console.WriteLine();
      Console.WriteLine(
        "Customer {0} placed order {1} on {2:d}",
        newOrder.CustomerID, newOrder.OrderID,
        newOrder.OrderDate);
      Console.WriteLine(
        "{0} units were ordered at {1:C} each",
        newOrder.Units, newOrder.UnitCost);
      Console.WriteLine(
        "The total cost of this order is {0:C}",
        newOrder.TotalCost);
    }

  }
}
