using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class OrdersStatusData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<OrdersStatu> m_ListOrdersStatus = new List<OrdersStatu>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}