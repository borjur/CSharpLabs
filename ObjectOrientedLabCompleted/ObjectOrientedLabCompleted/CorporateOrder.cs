using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace ObjectOrientedLabCompleted
{
  class CorporateOrder : Order, IShipping
  {
    private string _SalesRep;
    private string _Terms;
    private DateTime _PromisedDate =
      DateTime.Today.AddDays(14);
    private string _Shipper;
    private string _Priority;
    private DateTime _DeliveryDate; 

    public CorporateOrder()
    {
    }

    public CorporateOrder(
      int orderID, string customerID,
      DateTime orderDate, int units,
      decimal unitCost, string salesRep,
      string terms, DateTime promisedDate)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.OrderDate = orderDate;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
      this.SalesRep = salesRep;
      this.Terms = terms;
      this.PromisedDate = promisedDate;
    }

    public CorporateOrder(
      int orderID, string customerID,
      int units, decimal unitCost,
      string salesRep, string terms,
      DateTime promisedDate)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
      this.SalesRep = salesRep;
      this.Terms = terms;
      this.PromisedDate = promisedDate;
    }

    public string SalesRep
    {
      get
      { return _SalesRep; }
      set
      { _SalesRep = value; }
    }

    public string Terms
    {
      get
      { return _Terms; }
      set
      { _Terms = value; }
    }

    public DateTime PromisedDate
    {
      get
      { return _PromisedDate; }
      set
      { _PromisedDate = value; }
    }

    public int SaveOrder(string detail)
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineChars = "\r\n";

      string fileName = null;
      if (detail == "short")
      {
        fileName = string.Format(@"c:\{0}_short.xml",
          this.OrderID);
      }
      else
      {
        fileName = string.Format(@"c:\{0}.xml", this.OrderID);
      }

      XmlWriter writer = XmlWriter.Create(fileName, settings);

      writer.WriteStartDocument(true);
      writer.WriteStartElement("Order");
      writer.WriteElementString(
        "OrderID", this.OrderID.ToString());
      writer.WriteElementString(
        "CustomerID", this.CustomerID);
      writer.WriteElementString(
        "OrderDate", this.OrderDate.ToString("d"));

      if (detail != "short")
      {
        writer.WriteElementString(
          "Units", this.Units.ToString());
        writer.WriteElementString(
          "UnitCost", this.UnitCost.ToString());
        writer.WriteElementString(
          "TotalCost", this.TotalCost.ToString());
      }

      writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Close();

      if (File.Exists(fileName))
      {
        return 1;
      }
      else
      {
        return -1;
      }
    }


    #region IShipping Members

    public string Shipper
    {
      get
      { return _Shipper; }
      set
      { _Shipper = value; }
    }

    public string Priority
    {
      get
      { return _Priority; }
      set
      { _Priority = value; }
    }

    public DateTime DeliveryDate
    {
      get
      { return _DeliveryDate; }
      set
      { _DeliveryDate = value; }
    }

    public bool IsDelivered()
    {
      if (File.Exists(string.Format(@"c:\{0}_Delivery.xml", 
        this.OrderID)))
      {
        XmlReader reader = XmlReader.Create(
          string.Format(@"C:\{0}_Delivery.xml", OrderID));

        while (reader.ReadToFollowing("Order"))
        {
          reader.ReadToFollowing("OrderID");
          this.OrderID = int.Parse(reader.ReadInnerXml());
          reader.ReadToFollowing("Shipper");
          this.Shipper = reader.ReadInnerXml();
          reader.ReadToFollowing("Priority");
          this.Priority = reader.ReadInnerXml();
          reader.ReadToFollowing("DeliveryDate");
          this.DeliveryDate = Convert.ToDateTime(
            reader.ReadInnerXml());
        }
        return true;
      }
      else
      {
        return false;
      }
    }

    public void MarkAsDelivered(
      int orderID, string shipper, 
      string priority, DateTime deliveryDate)
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineChars = "\r\n";

      XmlWriter writer = XmlWriter.Create(
        string.Format(@"c:\{0}_Delivery.xml", 
        this.OrderID), settings);

      writer.WriteStartDocument(true);
      writer.WriteStartElement("Order");
      writer.WriteElementString("OrderID", 
        orderID.ToString());
      writer.WriteElementString("Shipper", 
        shipper.ToString());
      writer.WriteElementString("Priority", 
        priority.ToString());
      writer.WriteElementString("DeliveryDate", 
        deliveryDate.ToString("d"));
      writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Close();
    }

    #endregion

  }
}
