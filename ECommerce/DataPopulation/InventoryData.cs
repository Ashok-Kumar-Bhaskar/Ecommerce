using ECommerce.Interfaces;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class InventoryData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Inventory> m_ListInventory = new List<Inventory>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListInventory = new List<Inventory>() {
                new Inventory(){ Product_ID = 5000, Seller_ID = 740001, Stock = 50, Price = 21999 },
                new Inventory(){ Product_ID = 5000, Seller_ID = 740002, Stock = 20, Price = 22499}
      };
    }

    public IEnumerable<Inventory> ReturnListDataForInventory()
    {
      return m_ListInventory.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public InventoryData()
    {
      InitializeData();
    }
    #endregion
  }
}