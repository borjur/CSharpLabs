using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace ArraysLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      ListServices();

      Console.WriteLine();
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    private static void ListServices()
    {
      ServiceController[] services =
        ServiceController.GetServices();
      services = Array.FindAll(services, CheckService);
      Array.Sort(services, new CompareStatus());

      //foreach (ServiceController service in services)
      //{
      //  Console.WriteLine("{0}: {1}", 
      //    service.Status, service.DisplayName);
      //}

      ServiceController service = null;
      for (int i = 0; i < services.Length; i++)
      {
        service = services[i];
        Console.WriteLine("{2:D3}.) {0}: {1}",
          service.Status, service.DisplayName, i);
      }
    }

    private static bool CheckService(
      ServiceController service)
    {
      return service.CanStop && 
        (service.Status == ServiceControllerStatus.Running);
    }
  }
}
