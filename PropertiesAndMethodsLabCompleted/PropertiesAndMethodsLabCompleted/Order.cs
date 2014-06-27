using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace PropertiesAndMethodsLabCompleted
{
  class Order
  {
    private int _OrderID;
    private string _CustomerID;
    private DateTime _OrderDate = DateTime.Today;
    private int _Units;
    private decimal _UnitCost;
    private decimal _TotalCost;

    public Order()
    {
    }

    public Order(
      int orderID, string customerID,
      DateTime orderDate, int units,
      decimal unitCost)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.OrderDate = orderDate;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
    }

    public Order(
      int orderID, string customerID,
      int units, decimal unitCost)
    {
      this.OrderID = orderID;
      this.CustomerID = customerID;
      this.Units = units;
      this.UnitCost = unitCost;
      this.TotalCost = this.Units * this.UnitCost;
    }

    public int OrderID
    {
      get
      { return _OrderID; }
      set
      { _OrderID = value; }
    }

    public string CustomerID
    {
      get
      { return _CustomerID; }
      set
      { _CustomerID = value; }
    }

    public DateTime OrderDate
    {
      get
      { return _OrderDate; }
      set
      {
        if ((value > DateTime.Today))
        {
          throw new ArgumentException(
            "The order date can not be in the future");
        }
        else
        { _OrderDate = value; }
      }
    }

    public int Units
    {
      get
      { return _Units; }
      set
      {
        if ((value <= 0))
        {
          throw new ArgumentException(
            "Units must be greater than 0");
        }
        else
        { _Units = value; }
      }
    }

    public decimal UnitCost
    {
      get
      { return _UnitCost; }
      set
      {
        if ((value <= 0))
        {
          throw new ArgumentException(
            "Unit cost must be greater than 0");
        }
        else
        { _UnitCost = value; }
      }
    }

    public decimal TotalCost
    {
      get
      { return _TotalCost; }
      set
      { _TotalCost = _Units * _UnitCost; }
    }

    public int SaveOrder()
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineChars = "\r\n";

      XmlWriter writer = XmlWriter.Create(
        string.Format(@"c:\{0}.xml", this.OrderID),
        settings);

      writer.WriteStartDocument(true);
      writer.WriteStartElement("Order");
      writer.WriteElementString("OrderID",
        this.OrderID.ToString());
      writer.WriteElementString("CustomerID",
        this.CustomerID);
      writer.WriteElementString("OrderDate",
        this.OrderDate.ToString("d"));
      writer.WriteElementString("Units",
        this.Units.ToString());
      writer.WriteElementString("UnitCost",
        this.UnitCost.ToString());
      writer.WriteElementString("TotalCost",
        this.TotalCost.ToString());

      writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Close();

      if (File.Exists(
        string.Format(@"c:\{0}.xml", this.OrderID)))
      { return 1; }
      else
      { return -1; }
    }

    public void GetOrderInfo(int orderID)
    {
      XmlReader reader = XmlReader.Create(
        string.Format(@"C:\{0}.xml", orderID));

      while (reader.ReadToFollowing("Order"))
      {
      reader.ReadToFollowing("OrderID");
      this.OrderID = Convert.ToInt32(
        reader.ReadInnerXml());
      reader.ReadToFollowing("CustomerID");
      this.CustomerID = reader.ReadInnerXml();
      reader.ReadToFollowing("OrderDate");
      this.OrderDate = 
        Convert.ToDateTime(reader.ReadInnerXml());
      reader.ReadToFollowing("Units");
      this.Units = Convert.ToInt32(
        reader.ReadInnerXml());
      reader.ReadToFollowing("UnitCost");
      this.UnitCost = Convert.ToDecimal(
        reader.ReadInnerXml());
      reader.ReadToFollowing("TotalCost");
      this.TotalCost = Convert.ToDecimal(
        reader.ReadInnerXml());
      }
    }

  }
}
