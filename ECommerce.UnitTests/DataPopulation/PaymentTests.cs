using ECommerce.DataPopulation;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace ECommerce.UnitTests
{
  [TestClass]
  public class PaymentTests
  {
    #region [-- Properties --]
    private ECommerceEntities db = new ECommerceEntities();

    #endregion

    #region [-- Methods--]
    //Run this method only once, as Data Redundancy will take place
    private bool InsertDataAddToDB()
    {
      var m_PaymentData = new PaymentData();
      db.Payments.AddRange(m_PaymentData.ReturnListDataForPayment().ToList());

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
      var paymentListData = db.Payments.ToList();

      Assert.IsNotNull(paymentListData);
      Assert.AreEqual(paymentListData.Count, 2);
    }
    #endregion
  }
}
