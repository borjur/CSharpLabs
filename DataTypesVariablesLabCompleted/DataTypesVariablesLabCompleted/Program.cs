using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypesVariablesLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        // Clear the window
        Console.Clear();

        Console.Write(
          "Enter a to calculate a loan payment, " +
          "b to compare cars, x to exit: ");

        // Read a key from the user
        ConsoleKeyInfo key = Console.ReadKey();

        // Given the user's keypress, determine what to do
        char resultChar = char.ToUpper(key.KeyChar);
        if (resultChar == 'X')
        {
          // Stop running the code
          break;
        }

        if (resultChar == 'A')
        {
          CalcPayment();
        }
        else
        {
          CompareCars();
        }

        // Request a key before clearing the screen:
        Console.WriteLine();
        Console.Write("Press any key to continue...");
        Console.ReadKey();
      }
    }

    static void CalcPayment()
    {
      Console.Clear();

      string enteredString;
      double loanAmount;
      int numberOfPayments;
      double interestRate;
      double monthlyPayment;

      // Get information on the loan
      Console.WriteLine("Enter the amount of the loan:");
      enteredString = Console.ReadLine();
      loanAmount = Convert.ToDouble(enteredString);

      Console.WriteLine("Enter the number of payments:");
      enteredString = Console.ReadLine();
      numberOfPayments = Convert.ToInt32(enteredString);

      Console.WriteLine("Enter the interest rate (eg 6.50):");
      enteredString = Console.ReadLine();
      interestRate = Convert.ToDouble(enteredString);

      interestRate /= 1200;

      // Calculate the monthly payment
      monthlyPayment = -(-loanAmount *
         Math.Pow(1 + interestRate, numberOfPayments) /
         ((Math.Pow((1 + interestRate), numberOfPayments) - 1) /
         interestRate));

      // Display the monthly payment
      Console.WriteLine("The monthly payment is {0:C}",
         monthlyPayment);
    }

    struct Car
    {
      public string Name;
      public int CityMPG;
      public int HighwayMPG;
      public decimal GasCost;
    }

    static void CompareCars()
    {
      Console.Clear();

      Car myCar;
      Car newCar1;
      Car newCar2;

      string enteredstring;
      decimal gasPrice;
      int cityMiles;
      int highwayMiles;

      // Get information on the user's driving and the price of gas
      Console.WriteLine("Enter the number of city miles you drive:");
      enteredstring = Console.ReadLine();
      cityMiles = Convert.ToInt32(enteredstring);

      Console.WriteLine("Enter the number of highway miles you drive:");
      enteredstring = Console.ReadLine();
      highwayMiles = Convert.ToInt32(enteredstring);

      Console.WriteLine("Enter the cost of gas:");
      enteredstring = Console.ReadLine();
      gasPrice = Convert.ToDecimal(enteredstring);
      Console.WriteLine();

      // Get information on the user's current car
      Console.WriteLine("Enter the name of your car:");
      enteredstring = Console.ReadLine();
      myCar.Name = enteredstring;

      Console.WriteLine("Enter the city MPG:");
      enteredstring = Console.ReadLine();
      myCar.CityMPG = Convert.ToInt32(enteredstring);

      Console.WriteLine("Enter the highway MPG:");
      enteredstring = Console.ReadLine();
      myCar.HighwayMPG = Convert.ToInt32(enteredstring);
      Console.WriteLine();

      // Get information on the first new car
      Console.WriteLine("Enter the name of the new car:");
      enteredstring = Console.ReadLine();
      newCar1.Name = enteredstring;

      Console.WriteLine("Enter the city MPG:");
      enteredstring = Console.ReadLine();
      newCar1.CityMPG = Convert.ToInt32(enteredstring);

      Console.WriteLine("Enter the highway MPG:");
      enteredstring = Console.ReadLine();
      newCar1.HighwayMPG = Convert.ToInt32(enteredstring);
      Console.WriteLine();

      // Get information on the second new car
      Console.WriteLine("Enter the name of the new car:");
      enteredstring = Console.ReadLine();
      newCar2.Name = enteredstring;

      Console.WriteLine("Enter the city MPG:");
      enteredstring = Console.ReadLine();
      newCar2.CityMPG = Convert.ToInt32(enteredstring);

      Console.WriteLine("Enter the highway MPG:");
      enteredstring = Console.ReadLine();
      newCar2.HighwayMPG = Convert.ToInt32(enteredstring);
      Console.WriteLine();

      // Calculate the gas cost for the user's car
      myCar.GasCost = (Convert.ToDecimal(
        cityMiles / myCar.CityMPG) * gasPrice) +
        (Convert.ToDecimal(
        highwayMiles / myCar.HighwayMPG) * gasPrice);

      // Calculate the gas cost for the first new car
      newCar1.GasCost = (Convert.ToDecimal(
        cityMiles / newCar1.CityMPG) * gasPrice) +
        (Convert.ToDecimal(
        highwayMiles / newCar1.HighwayMPG) * gasPrice);

      // Calculate the gas cost for the second new car
      newCar2.GasCost = (Convert.ToDecimal(
        cityMiles / newCar2.CityMPG) * gasPrice) +
        (Convert.ToDecimal(
        highwayMiles / newCar2.HighwayMPG) * gasPrice);

      Console.WriteLine(
        "{0} will cost you {1:C} for gas",
        myCar.Name, myCar.GasCost);
      Console.WriteLine(
        "{0} will cost you {1:C} for gas",
        newCar1.Name, newCar1.GasCost);
      Console.WriteLine(
        "{0} will cost you {1:C} for gas",
        newCar2.Name, newCar2.GasCost);
      Console.WriteLine();

      if (myCar.GasCost > newCar1.GasCost |
        myCar.GasCost > newCar2.GasCost)
      {
        if (newCar1.GasCost > newCar2.GasCost)
        {
          Console.WriteLine(
            "You will spend less on gas if you buy {0}",
            newCar2.Name);
        }
      }
      else
      {
        Console.WriteLine(
          "You will spend more on gas if get a new car");
      }
    }

  }
}
