using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      //SortWriters();
      //FindWriters();
      //Comparisons();
      ShopForCars();

      Console.WriteLine();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

    private static void SortWriters()
    {
      string[] People = 
        { "Ken", "Robert", "Mary", "Andy" };

      Array.Sort(People);
      foreach (string person in People)
      {
        Console.WriteLine(person);
      }
      Console.WriteLine();

      Writer[] Writers = new Writer[4];
      Writers[0] = new Writer("Andy", "FL");
      Writers[1] = new Writer("Mary", "FL");
      Writers[2] = new Writer("Ken", "CA");
      Writers[3] = new Writer("Robert", "WA");

      //Array.Sort(Writers, new CompareWriterNames());
      //foreach (Writer author in Writers)
      //{
      //  Console.WriteLine(author);
      //}
      //Console.WriteLine();
      //Array.Sort(Writers, new CompareWriterStates());
      //foreach (Writer author in Writers)
      //{
      //  Console.WriteLine(author);
      //}

      Array.Sort(Writers);
      foreach (Writer author in Writers)
      {
        Console.WriteLine(author);
      }
    }

    private static void FindWriters()
    {
      Writer[] Writers = new Writer[4];
      Writers[0] = new Writer("Andy", "FL");
      Writers[1] = new Writer("Mary", "FL");
      Writers[2] = new Writer("Ken", "CA");
      Writers[3] = new Writer("Robert", "WA");

      Console.WriteLine("Writers in California:");
      int index = 0;
      while (true)
      {
        index = Array.FindIndex(Writers, index,
          Helpers.IsInCA);
        if (index == -1)
        { break; }
        else
        { Console.WriteLine(Writers[index]); }
        index += 1;
      }
      Console.WriteLine();

      Console.WriteLine("Writers in Florida:");
      index = 0;
      while (true)
      {
        index = Array.FindIndex(Writers, index,
          Helpers.IsInFL);
        if (index == -1)
        { break; }
        else
        { Console.WriteLine(Writers[index]); }
        index += 1;
      }
      Console.WriteLine();

      Console.WriteLine("Writers in Washington:");
      index = 0;
      while (true)
      {
        index = Array.FindIndex(Writers, index,
          Helpers.IsInWA);
        if (index == -1)
        { break; }
        else
        { Console.WriteLine(Writers[index]); }
        index += 1;
      }
    }

    private static void Comparisons()
    {
      House house1 = new House("Small house", 1500);
      House house2 = new House("Big house", 4000);

      Car car1 = new Car("Inexpensive car", 20000M);
      Car car2 = new Car("Expensive car", 50000M);

      int result = 0;
      string comparison = null;

      result = Helpers.Compare(house1, house2);
      if (result > 0)
      { comparison = "bigger than"; }
      else
      {
        if (result < 0)
        { comparison = "smaller than"; }
        else
        { comparison = "the same size as"; }
      }

      Console.WriteLine(
        "{0} ({1} sq ft) is {2} {3} ({4} sq ft)",
        house1.Description, house1.Size, comparison,
        house2.Description, house2.Size);
      Console.WriteLine();

      result = Helpers.Compare(car1, car2);
      if (result > 0)
      { comparison = "more expensive than"; }
      else
      {
        if (result < 0)
        { comparison = "less expensive than"; }
        else
        { comparison = "as expensive as"; }
      }

      Console.WriteLine("{0} ({1:C}) is {2} {3} ({4:C})",
        car1.Description, car1.Cost, comparison,
        car2.Description, car2.Cost);
    }

    private static void ShopForCars()
    {
      Car car1 = new Car("Inexpensive car", 20000M);
      OptionPackage option1 = new 
        OptionPackage("Sun roof",1500M);
      OptionPackage option2 = new 
        OptionPackage("Automatic",2500M);

      car1.Options.Add(option1);
      car1.Options.Add(option2);

      Console.WriteLine("{0} costs {1:C}", 
        car1.Description, car1.Cost);
      Console.WriteLine(
        "You selected the following options:");
      decimal totalCost1 = car1.Cost;
      foreach (OptionPackage _option in car1.Options)
      {
        Console.WriteLine("  {0} costs {1:C}", 
          _option.Description, _option.Cost);
        totalCost1 += _option.Cost;
      }
      Console.WriteLine("The total cost for {0} is {1:C}", 
        car1.Description, totalCost1);
      Console.WriteLine();

      Car car2 = new Car("Expensive car", 50000M);
      OptionPackage option3 = new 
        OptionPackage("Navigation package", 2000M);
      OptionPackage option4 = new 
        OptionPackage("Luxury package", 3000M);
      OptionPackage option5 = new 
        OptionPackage("Entertainment package", 4000M);

      car2.Options.Add(option3);
      car2.Options.Add(option4);
      car2.Options.Add(option5);

      Console.WriteLine("{0} costs {1:C}", 
        car2.Description, car2.Cost);
      Console.WriteLine(
        "You selected the following options:");
      decimal totalCost2 = car2.Cost;
      foreach (OptionPackage _option in car2.Options)
      {
        Console.WriteLine("  {0} costs {1:C}", 
          _option.Description, _option.Cost);
        totalCost2 += _option.Cost;
      }
      Console.WriteLine("The total cost for {0} is {1:C}", 
        car2.Description, totalCost2);
    }

  }
}
