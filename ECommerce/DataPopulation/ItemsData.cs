using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class ItemsData
  {
    #region [-- Properties --] 
    private IList<Item> m_ListItem = new List<Item>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForItem()
    {
      m_ListItem = new List<Item>() {
                new Item(){ Cart_ID = 50001, Commodity_ID = 210002, Quantity = 1, Amount = 21999},
                new Item(){ Cart_ID = 50001, Commodity_ID = 210003, Quantity = 1, Amount = 22499}
      };
    }

    public IEnumerable<Item> ReturnListDataForItem()
    {
      return m_ListItem.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public ItemsData()
    {
      InitializeDataForItem();
    }
    #endregion
  }
}