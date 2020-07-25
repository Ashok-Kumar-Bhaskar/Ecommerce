using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class CartData
  {
    #region [-- Properties --] 
    private IList<Cart> m_ListCart = new List<Cart>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForCart()
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
      InitializeDataForCart();
    }
    #endregion
  }
}