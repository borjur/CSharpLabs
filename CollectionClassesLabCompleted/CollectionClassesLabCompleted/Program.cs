using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CollectionClassesLabCompleted
{
  class Program
  {
    private static SortedDictionary<string, List<FileInfo>> extensions =
      new SortedDictionary<string, List<FileInfo>>();

    static void Main(string[] args)
    {
      FillData(@"C:\Windows", "*.*");
      DisplayData();

      Console.WriteLine();
      Console.WriteLine("Press any key to finish.");
      Console.ReadKey();
    }

    private static void DisplayData()
    {
      //  Display the extensions:
      foreach (string key in extensions.Keys)
      {
        Console.WriteLine(key);

        List<FileInfo> files = extensions[key];
        files.Sort(CompareSizes);

        foreach (System.IO.FileInfo file in extensions[key])
        {
          Console.WriteLine("  {0} ({1})", 
            file.Name, file.Length);
        }
      }
    }

    private static int CompareSizes(
      FileInfo file1, FileInfo file2)
    {
      int result = file1.Length.CompareTo(file2.Length);
      if (result == 0)
      {
        result = file1.Name.CompareTo(file2.Name);
      }
      return result;
    }

    private static void FillData(string path, string fileSpec)
    {
      DirectoryInfo dir = new DirectoryInfo(path);
      foreach (System.IO.FileInfo file in 
        dir.GetFiles(fileSpec))
      {
        string ext = file.Extension;
        if (!(extensions.ContainsKey(ext)))
        {
          //  Extension wasn't found, so add
          //  a new entry in the sorted dictionary:
          extensions.Add(ext, new List<FileInfo>());
        }
        //  Either way, add the file to the list of 
        //  files hanging off the sorted dictionary for 
        //  this extension:
        extensions[ext].Add(file);
      }
    }
  }
}
