using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      LogFile log = new LogFile("C:\\Boot.ini");
      Console.WriteLine(log.FileName);
      Console.WriteLine(log.ReadText());

      // You could also simply set the FileName property:
      log = new LogFile("C:\\MyLog.txt");
      log.WriteText(DateTime.Today.ToString());
      log.AppendText("Created this file.");
      log.AppendText("It's now: ", false);
      log.AppendText(DateTime.Now.ToLongTimeString());
      Console.WriteLine(log.ReadText());

      Console.WriteLine();
      Console.WriteLine("Press any key...");
      Console.ReadKey();
    }
  }
}
