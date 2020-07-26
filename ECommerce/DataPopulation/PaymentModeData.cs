using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class PaymentModeData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<PaymentMode> m_ListPaymentMode = new List<PaymentMode>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}