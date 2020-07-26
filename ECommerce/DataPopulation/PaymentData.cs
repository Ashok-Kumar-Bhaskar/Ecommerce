using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class PaymentData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Payment> m_ListPayment = new List<Payment>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListPayment = new List<Payment>() {
                new Payment(){ PaymentMode_ID = 742001, Paid = true },
                new Payment(){ PaymentMode_ID = 742002, Paid = true}
      };
    }

    public IEnumerable<Payment> ReturnListDataForPayment()
    {
      return m_ListPayment.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public PaymentData()
    {
      InitializeData();
    }
    #endregion
  }
}