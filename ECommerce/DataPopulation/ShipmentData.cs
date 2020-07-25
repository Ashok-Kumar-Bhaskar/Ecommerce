using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class ShipmentData
  {
    #region [-- Properties --] 
    private IList<Shipment> m_ListShipment = new List<Shipment>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForShipment()
    {
      m_ListShipment = new List<Shipment>() {
                new Shipment(){ AgentName = "BlueDart", IsDeleted = false },
                new Shipment(){ AgentName = "Delhivery", IsDeleted = false}
      };
    }

    public IEnumerable<Shipment> ReturnListDataForShipment()
    {
      return m_ListShipment.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public ShipmentData()
    {
      InitializeDataForShipment();
    }
    #endregion
  }
}