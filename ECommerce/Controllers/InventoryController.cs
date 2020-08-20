using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.Controllers
{
    public class InventoryController : ApiController
    {
      private ECommerceEntities db = new ECommerceEntities();

    [HttpPost]
    [Route("api/PostInventory")]
    public IHttpActionResult PostCategory(Inventory inventory)
    {
      try
      {
        Inventory inv = new Inventory();
        inv.Product_ID = inventory.Product_ID;
        inv.Seller_ID = inventory.Seller_ID;
        inv.Stock = inventory.Stock;
        inv.Price = inventory.Price;

        db.Inventories.Add(inv);
        db.SaveChanges();
        return Ok(inv);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/GetProductID")]
    public IHttpActionResult GetProductID()
    {
      try
      {
        var prodID = (from p in db.Products.OrderByDescending(e => e.Product_ID)
                      select new
                      {
                        p.Product_ID
                      }).FirstOrDefault();
        return Ok(prodID);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

  }
}
