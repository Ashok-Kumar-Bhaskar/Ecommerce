
using ECommerce.DBOperations;
using ECommerce.HelperClasses;
using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ECommerce.Controllers
{
  public class CartController : ApiController
  {
    private ECommerceEntities db = new ECommerceEntities();

    [HttpGet]
    [Route("api/GetCart")]
    public IHttpActionResult GetCart()
    {
      try
      {
        var cartList = (from c in db.Carts

                                         select new
                                         {
                                           c.User_ID,
                                           c.Cart_ID,
                                           c.Date,
                                           c.CartStatus_ID
                                         });
        
        return Ok(cartList.ToList());
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpPost]
    [Route("api/PostCart")]
    public IHttpActionResult PostCart(Cart cart)
    {
        try
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          db.Carts.Add(cart);
          db.SaveChanges();
          return Ok("Cart Added Successfully");
        }
        catch (Exception ex)
        {
          LogFile.WriteLog(ex);
          return BadRequest();
        }
      }

    [HttpPut]
    [Route("api/PutCart/{id=id}")]
    public IHttpActionResult PutCart(long id, CartStatu cartstatu)
    {
      try
      {
        if (!ModelState.IsValid)
        { 
          return BadRequest(ModelState);
        }

        var list = db.Carts.FirstOrDefault(e => e.Cart_ID == id);

        if(list == null)
        {
          return NotFound();
        }

        else
        {
          list.CartStatus_ID = cartstatu.CartStatus_ID;
          db.SaveChanges();
        }

        return Ok("Cart Updated Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/GetDetailsForCartPage")]
    public IHttpActionResult GetDetailsForCartPage()
    {
      try
      {
        DataOperations op = new DataOperations();
        var result = op.GetCartDetails();
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