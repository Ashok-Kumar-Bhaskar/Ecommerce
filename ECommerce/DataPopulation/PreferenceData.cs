using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class PreferenceData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Preference> m_ListPreference = new List<Preference>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListPreference = new List<Preference>() {
                new Preference(){ User_ID = 101, Theme_ID = 40000002 },
                new Preference(){ User_ID = 101, Theme_ID = 40000001}
      };
    }

    public IEnumerable<Preference> ReturnListDataForPreference()
    {
      return m_ListPreference.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public PreferenceData()
    {
      InitializeData();
    }
    #endregion
  }
}