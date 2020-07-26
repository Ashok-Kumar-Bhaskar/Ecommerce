using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class CartData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Cart> m_ListCart = new List<Cart>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListCart = new List<Cart>() {
                new Cart(){ User_ID = 101, CartStatus_ID = 45001}
      };
    }

    public IEnumerable<Cart> ReturnListDataForCart()
    {
      return m_ListCart.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public CartData()
    {
      InitializeData();
    }
    #endregion
  }
}