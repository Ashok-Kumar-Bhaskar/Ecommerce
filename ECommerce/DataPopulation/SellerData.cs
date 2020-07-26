using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class SellerData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Seller> m_ListSeller = new List<Seller>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}