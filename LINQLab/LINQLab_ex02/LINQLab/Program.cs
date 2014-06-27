using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.IO;

namespace IntroLab
{
  class Program
  {
      static void Main(string[] args)
      {
          ListServices();
          Console.ReadKey();
      }

      private static void ListServices()
      {
          var services =
            from service in ServiceController.GetServices()
            where service.Status == ServiceControllerStatus.Running
              && service.CanPauseAndContinue
            orderby service.DisplayName
            select new { Name = service.DisplayName };

          foreach (var service in services)
          {
              Console.WriteLine(service.Name);
          }
      }
  }
}
