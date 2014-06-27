using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace ArraysLabCompleted
{
  class CompareStatus : System.Collections.IComparer
  {
    #region IComparer Members

    public int Compare(object x, object y)
    {
      ServiceController service1 = (ServiceController)x;
      ServiceController service2 = (ServiceController)y;

      int result = service1.Status.CompareTo(service2.Status);
      if (result == 0)
      {
        result = service1.DisplayName.CompareTo(
          service2.DisplayName);
      }

      return result;
    }

    #endregion
  }
}
