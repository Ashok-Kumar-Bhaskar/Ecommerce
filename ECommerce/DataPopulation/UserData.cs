using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class UserData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<User> m_ListUser = new List<User>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListUser = new List<User>() {
                new User(){ FirstName ="Admin",Email="admin@psiog.com",Username="Admin",Password = "password", 
                  DefaultContact = 1234567890, Role="Admin",IsDeleted = false },
                new User(){ FirstName ="Ashok", LastName="Kumar" ,Email="redmoon.ashok@gmail.com",Username="Ashok",Password = "password",
                  DefaultContact = 9710948799, Role="Customer",IsDeleted = false }
      };
    }

    public IEnumerable<User> ReturnListDataForUser()
    {
      return m_ListUser.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public UserData()
    {
      InitializeData();
    }
    #endregion
  }
}