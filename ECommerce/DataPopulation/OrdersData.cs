using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class OrdersData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Order> m_ListOrder = new List<Order>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListOrder = new List<Order>() {
                new Order(){ User_ID = 101, Cart_ID = 50001, Payment_ID = 100001, Shipment_ID = 100001,
                            OrdersStatus_Code = 11002}
      };
    }

    public IEnumerable<Order> ReturnListDataForOrders()
    {
      return m_ListOrder.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public OrdersData()
    {
      InitializeData();
    }
    #endregion
  }
}