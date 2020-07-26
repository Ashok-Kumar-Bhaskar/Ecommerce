using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class ShipmentData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Shipment> m_ListShipment = new List<Shipment>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}