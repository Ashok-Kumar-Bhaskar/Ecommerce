using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class PreferenceData
  {
    #region [-- Properties --] 
    private IList<Preference> m_ListPreference = new List<Preference>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForPreference()
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
      InitializeDataForPreference();
    }
    #endregion
  }
}