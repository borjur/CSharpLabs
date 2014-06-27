using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExceptionLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //  Create the output folder. If the folder
        //  already exists, this code still won't fail:
        Directory.CreateDirectory(@"C:\Test");

        //  Copy a file:
        CopyFile(@"C:\boot.ini", @"C:\test\boot.ini");

        //  X.ini doesn't exist:
        CopyFile(@"C:\x.ini", @"C:\test\boot.ini");

        //  The T: drive doesn't exist:
        CopyFile(@"T:\boot.ini", @"C:\test.boot.ini");
      }
      catch (Exception)
      {
      }
    }

    private static void CopyFile(
      string source, string destination)
    {
      Console.Write(
        "Copy '{0}' to '{1}': ", source, destination);

      try
      {
        //  Copy the file:
        File.Copy(source, destination);
        Console.WriteLine("successful");
      }
      catch (UnauthorizedAccessException)
      {
        Console.WriteLine(
          "You don't have permission to copy the file.");
      }
      catch (ArgumentNullException)
      {
        Console.WriteLine(
          "Either the source or destination contained " +
          "a null string.");
      }
      catch (ArgumentException)
      {
        Console.WriteLine(
          "Either one of the names is invalid, " +
          "or the source or destination is a directory, " +
          "not a file.");
      }
      catch (PathTooLongException)
      {
        Console.WriteLine(
          "File names must be less than 260 characters.");
      }
      catch (DirectoryNotFoundException)
      {
        Console.WriteLine(
          "The directory is invalid, " +
          "perhaps on an unmapped drive.");
      }
      catch (FileNotFoundException)
      {
        Console.WriteLine(
          "The source file wasn't found.");
      }
      catch (IOException)
      {
        Console.WriteLine(
          "Either the destination file exists, " +
          "or a general I/O error occurred.");
      }
      catch (NotSupportedException)
      {
        Console.WriteLine(
          "Either the source or the destination " +
          "file name was in an invalid format.");
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        Console.Write("Press ENTER to continue.");
        Console.ReadLine();
      }
    }
  }
}
