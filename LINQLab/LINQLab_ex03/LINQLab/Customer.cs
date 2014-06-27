using System.Data.Linq.Mapping;

[Table(Name = "Customers")]
public class Customer
{
    [Column(IsPrimaryKey = true)]
  public string CustomerID { get; set; }

    [Column()]
  public string ContactName { get; set; }

    [Column()]
  public string Country { get; set; }

    [Column(Name = "Phone")]
  public string HomePhone { get; set; }
}
