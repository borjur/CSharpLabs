using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace FlowControlLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      // ListServices1();
      // ListServices2();
      ListServices3();

      Console.WriteLine();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

    private static void ListServices1()
    {
      ServiceController[] services = 
        ServiceController.GetServices();
      for (int i = 0; i < services.Length; i++)
      {
        ServiceController service = services[i];
        Console.WriteLine("{0} ({1})",
         service.DisplayName, service.ServiceName);
      }
    }

    private static void ListServices2()
    {
      foreach (ServiceController service in 
        ServiceController.GetServices())
      {
        Console.WriteLine("{0} ({1})",
         service.DisplayName, service.ServiceName);
      }
    }

    private static void ListServices3()
    {
      foreach (ServiceController service in
        ServiceController.GetServices())
      {
        string status = string.Empty;
        switch (service.Status)
        {
          case ServiceControllerStatus.Paused:
            status = "Paused ";
            break;
          case ServiceControllerStatus.Running:
            status = "Running";
            break;
          case ServiceControllerStatus.Stopped:
            status = "Stopped";
            break;
          default:
            status = "Unknown";
            break;
        }
        Console.WriteLine("[{0}] {1} ({2})", 
          status, service.DisplayName, service.ServiceName);
      }
    }
  }
}
