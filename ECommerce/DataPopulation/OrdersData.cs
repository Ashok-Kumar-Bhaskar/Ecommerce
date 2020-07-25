using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class OrdersData
  {
    #region [-- Properties --] 
    private IList<Order> m_ListOrder = new List<Order>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForOrder()
    {
      m_ListOrder = new List<Order>() {
                new Order(){ User_ID = 101, Cart_ID = 50001, Payment_ID = 100001, Shipment_ID = 100001,
                            OrdersStatus_Code = 11002}
      };
    }

    public IEnumerable<Order> ReturnListDataForOrder()
    {
      return m_ListOrder.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public OrdersData()
    {
      InitializeDataForOrder();
    }
    #endregion
  }
}