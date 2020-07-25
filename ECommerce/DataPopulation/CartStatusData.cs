using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class CartStatusData
  {
    #region [-- Properties --] 
    private IList<CartStatu> m_ListCartStatus = new List<CartStatu>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForCartStatus()
    {
      m_ListCartStatus = new List<CartStatu>() {
                new CartStatu(){ Description="Ordered" },
                new CartStatu(){ Description="Timed Out" },
                new CartStatu(){ Description="Cancelled" }
      };
    }

    public IEnumerable<CartStatu> ReturnListDataForCartStatus()
    {
      return m_ListCartStatus.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public CartStatusData()
    {
      InitializeDataForCartStatus();
    }
    #endregion

  }
}