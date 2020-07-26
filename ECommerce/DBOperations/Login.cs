using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace ECommerce.DBOperations
{
  public class Login
  {
    #region [-- Properties --] 
    private User user = new User();

    #region [-- Username --]
    private string m_Username { get; set; }
    public string Username
    {
      get{
        return m_Username;
      }      
      set => m_Username = value;
    }
    #endregion

    #region [-- Password --]
    private string m_Password { get; set; }
    public string Password
    {
      get{
        return m_Password;
      }
      set => m_Password = value;
    }
    #endregion

    #endregion

    #region [-- Methods --]
    public bool? IsUsernameExist(string givenUsername)
    {
      try {
        using (ECommerceEntities db = new ECommerceEntities())
        {
          var result = db.Users.Where(u => u.Username == givenUsername).FirstOrDefault();
          return result == null ? false : true;
        }
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public bool? IsEmailExist(string givenEmail)
    {
      try {
        using (ECommerceEntities db = new ECommerceEntities())
        {
          var result = db.Users.Where(u => u.Email == givenEmail).FirstOrDefault();
          return result == null ? false : true;
        }
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public bool? IsPhoneNumberExist(long givenPhoneNumber)
    {
      try
      {
        using (ECommerceEntities db = new ECommerceEntities())
        {
          var result = db.Users.Where(u => u.DefaultContact == givenPhoneNumber).FirstOrDefault();
          return result == null ? false : true;
        }
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public User GetUserDetails(string givenUsername)
    {
      try {
        using (ECommerceEntities db = new ECommerceEntities())
        {
          var user = db.Users.Where(u => u.Username == givenUsername).FirstOrDefault();
          return user == null ? null : user;
        }
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return null;
      }
    }
    public bool? CheckForValidCredentials(string givenUsername, string givenPassword)
    {
      try {
        if (givenUsername == null || givenPassword == null)
          return false;

        if (IsUsernameExist(givenUsername) == true) {
          var user = GetUserDetails(givenUsername);
          if (user.Password == givenPassword) { 
            return true; 
          }           
          return false;
        }
        return false;
      }

      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    #endregion
  }
}