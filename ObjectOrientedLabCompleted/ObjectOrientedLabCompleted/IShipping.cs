using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedLabCompleted
{
  interface IShipping
  {
    string Shipper { set; get; }
    string Priority { set; get; }
    DateTime DeliveryDate { set; get; }

    bool IsDelivered();

    void MarkAsDelivered(
      int orderID, string shipper, 
      string priority, DateTime deliveryDate);
  }
}
