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
      [Route("api/GetOrders")]
      public IHttpActionResult GetOrders()
      {
        try
        {
          DataOperations op = new DataOperations();
          var result = op.GetOrderDetails();

          return Ok(result);
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
    }
}
