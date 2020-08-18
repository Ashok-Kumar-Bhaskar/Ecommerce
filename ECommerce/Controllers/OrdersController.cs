using ECommerce.DBOperations;
using ECommerce.HelperClasses;
using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ECommerce.Controllers
{
    public class OrdersController : ApiController
    {
      private ECommerceEntities db = new ECommerceEntities();

    [HttpGet]
    [Route("api/GetOrdersList/{id=id}")]
    public IHttpActionResult GetOrdersList(long id)
    {
      try
      {
        var list = (from u in db.Users.Where(e => e.User_ID == id) join
                      o in db.Orders on u.User_ID equals o.User_ID join
                     c in db.Carts on o.Cart_ID equals c.Cart_ID join
                     i in db.Items on c.Cart_ID equals i .Cart_ID join
                     inv in db.Inventories on i.Commodity_ID equals inv.Commodity_ID join
                     p in db.Products on inv.Product_ID equals p.Product_ID

                     select new
                     {
                       i.Amount, i.Quantity, p.ProductName, p.Brand, p.Color,
                       p.Variance, o.Date, o.Orders_ID, o.DeliveryDate
                     });

        return Ok(list);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

        [HttpGet]
    [Route("api/GetOrdersID/{id=id}")]
    public IHttpActionResult GetOrdersID(long id)
    {
      try
      {
        var list = (from u in db.Users.Where(a => a.User_ID==id) join
                      o in db.Orders on u.User_ID equals o.User_ID 

                     select new
                     {
                       o.Orders_ID, o.Date
                     }).Distinct();

        return Ok(list);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }
    [HttpGet]
      [Route("api/GetInvoice/{id=id}")]
      public IHttpActionResult GetInvoice(long id)
      {
        try
        {
          DataOperations op = new DataOperations();
          var result = op.GetInvoiceDetails(id);
          return Ok(result);
        }

        catch (Exception e)
        {
          LogFile.WriteLog(e);
          return BadRequest();
        }
      }

    [HttpPost]
    [Route("api/PostOrder")]
    public IHttpActionResult PostOrder(Order order)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        db.Orders.Add(order);
        db.SaveChanges();
        return Ok("Order Added Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }


  }
}
