using System;
using System.Collections.Generic;
using System.IO;

namespace DelegatesLabCompleted
{
  public delegate void BeforeFileFoundHandler(
    FileInfo file, ref Boolean Cancel);
  public delegate void FileFoundEventHandler(Object sender, FileFoundEventArgs e);
  public delegate void BeforeFileFoundCancelHandler(
   object sender, FileFoundCancelEventArgs e);

  class Program
  {
    private static String extToSkip = ".txt";

    private static void HandleFileFound(
      Object sender, FileFoundEventArgs e)
    {
      Console.WriteLine(e.FileFound.Name);
    }

    static void Main(string[] args)
    {
      // FileSearchA fs = new FileSearchA(@"C:\", "*.*", false);
      // FileSearchB fs = new FileSearchB(@"C:\", "*.*", false);
      // FileSearchC fs = new FileSearchC(@"C:\", "*.*", false);

      FileSearchD fs = new FileSearchD(@"C:\", "*.*", false);
      fs.FileFound +=
        new FileFoundEventHandler(HandleFileFound);
      fs.BeforeFileFound += 
        new BeforeFileFoundCancelHandler(BeforeHandler);
      //fs.Handler = BeforeHandler;
      // fs.BeforeFileFound += new BeforeFileFoundHandler(BeforeHandler);
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

    //private static void BeforeHandler(
    //  FileInfo file, ref Boolean cancel)
    //{
    //  cancel = AcceptFile(file);
    //}

    private static void BeforeHandler(
      Object sender, FileFoundCancelEventArgs e)
    {
      e.Cancel = AcceptFile(e.FileFound);
    }
  }
}
