using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.IO;
using System.Data.Linq;
using System.Xml.Linq;

namespace IntroLabCompleted
{
  class Program
  {
    static void Main(string[] args)
    {
      CreateXML();
      //ListCustomers();
      // ListServices();
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

    private static void ListCustomers()
    {
      DataContext dc = 
        new DataContext(
          Properties.Settings.Default.
          NorthwindConnectionString);
      var customersTable = dc.GetTable<Customer>();

      var customers = 
        from cust in customersTable 
        where cust.Country == "France"
        orderby cust.ContactName
          select cust;

      foreach (var cust in customers)
      {
        Console.WriteLine("{0}: {1}", 
          cust.ContactName, cust.HomePhone);
      }
    }

    private static void CreateXML()
    {
      DataContext dc =
        new DataContext(
          Properties.Settings.Default.
          NorthwindConnectionString);
      var customersTable = dc.GetTable<Customer>();

      var customers =
        from cust in customersTable
        where cust.Country == "USA"
        orderby cust.ContactName
        select cust;

      var customerXML =
        new XElement("Contacts",
          from cust in customers
          select
            new XElement("Contact",
              cust.ContactName,
              new XAttribute("Phone", cust.HomePhone),
              new XAttribute("CustomerID", cust.CustomerID)
            )
        );

      Console.WriteLine(customerXML.ToString());
    }

  }
}
