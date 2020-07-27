using ECommerce.DataPopulation;
using ECommerce.DBOperations;
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
    private PaymentData m_PaymentData = new PaymentData();
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
        db.Payments.AddRange(m_PaymentData.ReturnListDataForPayment().ToList());
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
      var paymentListData = db.Payments.ToList();

      Assert.IsNotNull(paymentListData);
      Assert.AreEqual(paymentListData.Count, 2);
    }
    #endregion
  }
}
