using ECommerce.Interfaces;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class InvoiceData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Invoice> m_ListInvoice = new List<Invoice>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
    {
      m_ListInvoice = new List<Invoice>() {
                new Invoice(){ Orders_ID = 700002 }
      };
    }

    public IEnumerable<Invoice> ReturnListDataForInvoice()
    {
      return m_ListInvoice.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public InvoiceData()
    {
      InitializeData();
    }
    #endregion
  }
}