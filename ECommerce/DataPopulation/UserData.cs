using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class UserData
  {
    #region [-- Properties --] 
    private IList<User> m_ListUser = new List<User>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForUser()
    {
      m_ListUser = new List<User>() {
                new User(){ FirstName ="Admin",Email="admin@psiog.com",Username="Admin",Password = "password", 
                  DefaultContact = 1234567890, Role="Admin",IsDeleted = false },
                new User(){ FirstName ="Ashok", LastName="Kumar" ,Email="redmoon.ashok@gmail.com",Username="Ashok",Password = "password",
                  DefaultContact = 9710948799, Role="Admin",IsDeleted = false }
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
      InitializeDataForUser();
    }
    #endregion
  }
}