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
                new Address(){ User_ID = 101, Door = 57, Street1 = "Sri Venkateshwara Nagar", Street2 = "1st Cross Street", Area = "Pallikaranai",
                                City = "Chennai", State = "Tamil Nadu", Pincode = 600100, Contact = 9710948799,
                                AlternateContact = 9710949736, IsShipping = true, IsDeleted = false},
                new Address(){ User_ID = 101, Door = 5, Street1 = "Nehru Steert", Area = "Adyar",
                                City = "Chennai", State = "Tamil Nadu", Pincode = 600045, Contact = 9710948799,
                                IsShipping = false, IsDeleted = false}
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