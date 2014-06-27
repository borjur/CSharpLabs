using System;
using System.Collections.Generic;
using System.Text;

namespace IntroLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      string inputString;
      int inputLength;

      // Prompt the user for a string:
      Console.Write("Enter a string: ");
      inputString = Console.ReadLine();

      // Calculate the number of characters in the string:
      inputLength = inputString.Length;

      // Display the results:
      Console.WriteLine("The string '" + inputString + "'" +
        " contains " + inputLength + " characters.");
      Console.ReadKey();
    }
  }
}
