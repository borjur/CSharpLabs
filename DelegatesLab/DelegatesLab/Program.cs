using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesLab
{
  public delegate void FileFoundEventHandler(Object sender, FileFoundEventArgs e);

  class Program
  {
    private static String extToSkip = ".txt";

    private static void HandleFileFound(Object sender, FileFoundEventArgs e)
    {
      Console.WriteLine(e.FileFound.Name);
    }

    static void Main(string[] args)
    {
      FileSearchA fs = new FileSearchA(@"C:\", "*.*", false);

      fs.FileFound += 
        new FileFoundEventHandler(HandleFileFound);
      fs.Execute();

      Console.WriteLine();
      Console.Write("Press any key to continue...");
      Console.ReadKey();
    }

    private static Boolean AcceptFile(FileInfo file)
    {
      return String.Compare(
        file.Extension, extToSkip, true) == 0;
    }
  }
}
