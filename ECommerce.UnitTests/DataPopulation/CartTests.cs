using ECommerce.DataPopulation;
using ECommerce.DBOperations;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ECommerce.UnitTests
{
  [TestClass]
  public class CartTests
  {
    #region [-- Properties --]
    private ECommerceEntities db = new ECommerceEntities();
    private CartData m_CartData = new CartData();
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
        db.Carts.AddRange(m_CartData.ReturnListDataForCart().ToList());
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
      var cartListData = db.Carts.ToList();

      Assert.IsNotNull(cartListData);
      Assert.AreEqual(cartListData.Count, 4);
    }
    #endregion
  }
}
