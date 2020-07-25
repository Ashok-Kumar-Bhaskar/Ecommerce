using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class PaymentModeData
  {
    #region [-- Properties --] 
    private IList<PaymentMode> m_ListPaymentMode = new List<PaymentMode>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForPaymentMode()
    {
      m_ListPaymentMode = new List<PaymentMode>() {
                new PaymentMode(){ Mode = "Credit Card", IsDeleted = false },
                new PaymentMode(){ Mode = "Debit Card", IsDeleted = false}
      };
    }

    public IEnumerable<PaymentMode> ReturnListDataForPaymentMode()
    {
      return m_ListPaymentMode.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public PaymentModeData()
    {
      InitializeDataForPaymentMode();
    }
    #endregion
  }
}