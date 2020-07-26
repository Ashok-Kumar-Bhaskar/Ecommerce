using ECommerce.DataPopulation;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ECommerce.UnitTests
{
  [TestClass]
  public class OrderStatusTests
  {
    #region [-- Properties --]
    private ECommerceEntities db = new ECommerceEntities();

    #endregion

    #region [-- Methods--]
    //Run this method only once, as Data Redundancy will take place
    private bool InsertDataAddToDB()
    {
      var m_OrdersStatusData = new OrdersStatusData();
      db.OrdersStatus.AddRange(m_OrdersStatusData.ReturnListDataForOrdersStatus().ToList());

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
      var ordersStatusListData = db.OrdersStatus.ToList();

      Assert.IsNotNull(ordersStatusListData);
      Assert.AreEqual(ordersStatusListData.Count, 2);
    }
    #endregion
  }
}
