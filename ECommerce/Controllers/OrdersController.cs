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
      [Route("api/GetOrders")]
      public IHttpActionResult GetOrders()
      {
        try
        {
          var ordersList = (from o in db.Orders join
                           c in db.Carts on o.Cart_ID equals c.Cart_ID join
                           i in db.Items on c.Cart_ID equals i.Cart_ID join
                           u in db.Users on o.User_ID equals u.User_ID join
                           s in db.Shipments on o.Shipment_ID equals s.Shipment_ID join
                           p in db.Payments on o.Payment_ID equals p.Payment_ID join
                           pm in db.PaymentModes on p.PaymentMode_ID equals pm.PaymentMode_ID
                
                          select new
                          {
                            o.Orders_ID, o.User_ID, o.Date, o.Shipment_ID, o.Payment_ID, c.Cart_ID, i.Items_ID, i.Commodity_ID,
                            i.Amount, i.Quantity, u.FirstName, u.LastName, s.AgentName, pm.Mode
                          
                          });

          return Ok(ordersList.ToList());
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
          var invoiceList = (from o in db.Orders.Where(e => e.Orders_ID == id) join
                           c in db.Carts on o.Cart_ID equals c.Cart_ID join
                           i in db.Items on c.Cart_ID equals i.Cart_ID join
                           u in db.Users on o.User_ID equals u.User_ID join
                           s in db.Shipments on o.Shipment_ID equals s.Shipment_ID join
                           p in db.Payments on o.Payment_ID equals p.Payment_ID join
                           pm in db.PaymentModes on p.PaymentMode_ID equals pm.PaymentMode_ID
                
                          select new
                          {
                            o.Orders_ID, o.User_ID, o.Date, o.DeliveryDate, o.Payment_ID, c.Cart_ID, i.Items_ID, i.Commodity_ID,
                            i.Amount, i.Quantity, Name = u.FirstName + " " + u.LastName, s.AgentName, pm.Mode, p.Paid
                          
                          });

     
          return Ok(invoiceList.ToList());
        }

        catch (Exception e)
        {
          LogFile.WriteLog(e);
          return BadRequest();
        }
      }
    }
}
