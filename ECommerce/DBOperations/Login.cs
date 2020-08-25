using ECommerce.DataPopulation;
using ECommerce.Helper_Classes;
using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ECommerce.DBOperations
{
  public class Login
  {
    private ECommerceEntities db = new ECommerceEntities();
    #region [-- Methods --]
    public string userName { get; set; }
    public string password { get; set; }

    public static string LoginAttempt(string username, string password, out User user) //Login function
    {
      try
      {
        using (ECommerceEntities db = new ECommerceEntities())
        {
          user = db.Users.Where(l => l.Username == username).FirstOrDefault();
          password = PasswordHash.GenerateHash(password);
          if (user != null)
          {
            if (String.Compare(password, user.Password) == 0)
            {
              return "Successfull";
            }
            else
            {
              user = null;
              return "Password is Wrong";
            }
          }
          else
          {
            user = null;
            return "Invalid Credentials";
          }
        }
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        user = null;
        return "Exception Caused";
      }
    }

    public User FindUser(string givenUsername)
    {
      try
      {
          var result = db.Users.Where(u => u.Username == givenUsername).FirstOrDefault();
          return result == null ? null: result;
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return null;
      }
    }

    public bool IsUsernameExist(string givenUsername)
    {
      try {
          var result = db.Users.Where(u => u.Username == givenUsername).FirstOrDefault();
          return result == null ? false : true;
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public bool? IsValidPhoneNumber(string givenPhoneNumber)
    {
      String regx = "(0/91)?[7-9][0-9]{9}";
      bool result = Regex.Match(givenPhoneNumber,regx).Success;
      Console.Write(result);
      return result;
    }

    public bool? IsValidEmail(string givenEmail)
    {
      Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
      Match match = regex.Match(givenEmail);
      bool result = match.Success;
      Console.Write(result);
      return result;
    }

    public bool? IsEmailExist(string givenEmail)
    {
      try {
          var result = db.Users.Where(u => u.Email == givenEmail).FirstOrDefault();
          return result == null ? false : true;
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public bool? IsPhoneNumberExist(long givenPhoneNumber)
    {
      try {
          var result = db.Users.Where(u => u.DefaultContact == givenPhoneNumber).FirstOrDefault();
          return result == null ? false : true;
      }
      catch (Exception ex) {
        LogFile.WriteLog(ex);
        return false;
      }
    }

    public User GetUserDetails(string givenUsername)
    {
      try {
          var user = db.Users.Where(u => u.Username == givenUsername).FirstOrDefault();
          return user == null ? null : user;
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