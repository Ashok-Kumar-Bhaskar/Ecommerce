using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class ThemeData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Theme> m_ListTheme = new List<Theme>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListTheme = new List<Theme>() {
                new Theme(){ ThemeName = "Normal Mode", IsDeleted = false },
                new Theme(){ ThemeName = "Dark Mode", IsDeleted = false}
      };
    }

    public IEnumerable<Theme> ReturnListDataForTheme()
    {
      return m_ListTheme.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public ThemeData()
    {
      InitializeData();
    }
    #endregion
  }
}