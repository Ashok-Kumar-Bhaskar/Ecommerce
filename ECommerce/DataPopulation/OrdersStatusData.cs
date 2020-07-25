using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class OrdersStatusData
  {
    #region [-- Properties --] 
    private IList<OrdersStatu> m_ListOrdersStatus = new List<OrdersStatu>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForOrdersStatus()
    {
      m_ListOrdersStatus = new List<OrdersStatu>() {
                new OrdersStatu(){ Status = "Initiated"  },
                new OrdersStatu(){ Status = "Packed"}
      };
    }

    public IEnumerable<OrdersStatu> ReturnListDataForOrdersStatus()
    {
      return m_ListOrdersStatus.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public OrdersStatusData()
    {
      InitializeDataForOrdersStatus();
    }
    #endregion
  }
}