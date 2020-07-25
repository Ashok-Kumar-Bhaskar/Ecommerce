using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class SellerData
  {
    #region [-- Properties --] 
    private IList<Seller> m_ListSeller = new List<Seller>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForSeller()
    {
      m_ListSeller = new List<Seller>() {
                new Seller(){ SellerName = "Delhi Enterprise", IsDeleted = false },
                new Seller(){ SellerName = "Madras Godown", IsDeleted = false}
      };
    }

    public IEnumerable<Seller> ReturnListDataForSeller()
    {
      return m_ListSeller.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public SellerData()
    {
      InitializeDataForSeller();
    }
    #endregion
  }
}