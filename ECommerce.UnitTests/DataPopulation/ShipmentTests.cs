﻿using ECommerce.DataPopulation;
using ECommerce.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests
{
  [TestClass]
  public class ShipmentTests
  {
    #region [-- Properties --]
    private ECommerceEntities db = new ECommerceEntities();

    #endregion

    #region [-- Methods--]
    //Run this method only once, as Data Redundancy will take place
    private bool InsertDataAddToDB()
    {
      var m_ShipmentData = new ShipmentData();
      db.Shipments.AddRange(m_ShipmentData.ReturnListDataForShipment().ToList());

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
      var shipmentListData = db.Shipments.ToList();

      Assert.IsNotNull(shipmentListData);
      Assert.AreEqual(shipmentListData.Count, 2);
    }
    #endregion
  }
}