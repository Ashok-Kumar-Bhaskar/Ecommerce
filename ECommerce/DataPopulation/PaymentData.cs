using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class PaymentData
  {
    #region [-- Properties --] 
    private IList<Payment> m_ListPayment = new List<Payment>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForPayment()
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
      InitializeDataForPayment();
    }
    #endregion
  }
}