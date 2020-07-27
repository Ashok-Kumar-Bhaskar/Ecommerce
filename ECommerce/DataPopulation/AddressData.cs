using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation 
{
  public class AddressData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Address> m_ListAddress = new List<Address>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListAddress = new List<Address>() {
                new Address(){ User_ID = 101, Door = 135, Street1 = "Kumaran Street", Street2 = "Hareram Street", Area = "Rajajipuram Nagar",
                                City = "Thiruvallur", State = "Tamil Nadu", Pincode = 602001, Contact = 9710941456,
                                AlternateContact = 9710949714, IsShipping = true, IsDeleted = false}
      };
    }

    public IEnumerable<Address> ReturnListDataForAddress()
    {
      return m_ListAddress.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public AddressData()
    {
      InitializeData();
    }
    #endregion
  }
}