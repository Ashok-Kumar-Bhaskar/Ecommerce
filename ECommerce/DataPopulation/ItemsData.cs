using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class ItemsData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Item> m_ListItem = new List<Item>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}