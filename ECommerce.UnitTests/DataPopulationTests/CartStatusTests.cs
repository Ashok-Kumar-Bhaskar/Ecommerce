﻿
using System.Linq;
using ECommerce.DataPopulation;
using ECommerce.DBOperations;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.UnitTests
{
  [TestClass]
  public class CartStatusTests
  {
      #region [-- Properties --]
      private ECommerceEntities db = new ECommerceEntities();
      private CartStatusData m_CartStatusData = new CartStatusData();
      private Login login = new Login();
      private User user = new User();

      #endregion

      #region [-- Methods--]
      //Run this method only once, as Data Redundancy will take place
      private bool InsertDataAddToDB(string username)
      {
        user = login.FindUser(username);
        if (user.Role == "Admin")
        {
          db.CartStatus.AddRange(m_CartStatusData.ReturnListDataForCartStatus().ToList());
        }
        else
        {
          return false;
        }

        int result = db.SaveChanges();
        if (result == 0)
          return false;
        else
          return true;
      }
      #endregion

      #region [-- Test Methods--]
      //Run this method only once, as Data Redundancy will take place
      [TestMethod]
      public void CheckWhetherDataHasBeenAdded_ByAdmin()
      {
        bool result = InsertDataAddToDB("Admin");

        Assert.IsTrue(result);
      }

      [TestMethod]
      //Run this method only once, as Data Redundancy will take place
      public void CheckWhetherDataCannotBeAdded_ByUser()
      {
        bool result = InsertDataAddToDB("Ashok");

        Assert.IsFalse(result);
      }

      [TestMethod]
      public void CheckWhetherItemsCountIsEqual()
      {
        var cartStatusListData = db.CartStatus.ToList();

        Assert.IsNotNull(cartStatusListData);
        Assert.AreEqual(cartStatusListData.Count, 2);
      }
      #endregion
    }
  }