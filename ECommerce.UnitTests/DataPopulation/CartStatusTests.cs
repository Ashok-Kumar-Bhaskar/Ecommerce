
using System.Linq;
using ECommerce.DataPopulation;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.UnitTests
{
  [TestClass]
  public class CartStatusTests
  {
    #region [-- Properties --]
    private ECommerceEntities db = new ECommerceEntities();

    #endregion

    #region [-- Methods--]
    //Run this method only once, as Data Redundancy will take place
    private bool InsertDataAddToDB()
    {
      var m_CartStatusData = new CartStatusData();
      db.CartStatus.AddRange(m_CartStatusData.ReturnListDataForCartStatus().ToList());

      var result = db.SaveChanges();
      if (result == 0)
        return false;
      else
        return true;
    }
    #endregion

    #region [-- Test Methods--]
    [TestMethod]
    public void CheckWhetherDataHasBeenAdded()
    {
      var result = InsertDataAddToDB();

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void CheckWhetherItemsCountIsEqual()
    {
      var cartStatusListData = db.CartStatus.ToList();

      Assert.IsNotNull(cartStatusListData);
      Assert.AreEqual(cartStatusListData.Count, 3);
    }
    #endregion
  }
}
