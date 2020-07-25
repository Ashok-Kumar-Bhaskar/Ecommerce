using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class CategoryData
  {
    #region [-- Properties --] 
    private IList<Category> m_ListCategory = new List<Category>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForCategory()
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
      InitializeDataForCategory();
    }
    #endregion
  }
}