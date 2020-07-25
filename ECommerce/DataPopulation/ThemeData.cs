using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class ThemeData
  {
    #region [-- Properties --] 
    private IList<Theme> m_ListTheme = new List<Theme>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForTheme()
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
      InitializeDataForTheme();
    }
    #endregion
  }
}