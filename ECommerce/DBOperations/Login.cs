﻿using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Linq;

namespace ECommerce.DBOperations
{
  public class Login
  {
    private ECommerceEntities db = new ECommerceEntities();
    #region [-- Methods --]
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

    public bool? IsUsernameExist(string givenUsername)
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

    //public bool? IsValidPhoneNumber(object givenObject)
    //{
    //  object.defaultPhonenumber 
    //}

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