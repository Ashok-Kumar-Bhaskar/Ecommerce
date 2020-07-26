using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class CartStatusData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<CartStatu> m_ListCartStatus = new List<CartStatu>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion

  }
}