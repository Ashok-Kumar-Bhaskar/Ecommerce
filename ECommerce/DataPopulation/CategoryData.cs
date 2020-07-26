using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class CategoryData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Category> m_ListCategory = new List<Category>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListCategory = new List<Category>() {
                new Category(){ CategoryName = "Smartphones", IsDeleted = false },
                new Category(){ CategoryName = "Laptops", IsDeleted = false}
      };
    }

    public IEnumerable<Category> ReturnListDataForCategory()
    {
      return m_ListCategory.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public CategoryData()
    {
      InitializeData();
    }
    #endregion
  }
}