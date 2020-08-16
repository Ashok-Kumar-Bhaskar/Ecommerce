
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
    [Route("api/GetCart/{id=id}")]
    public IHttpActionResult GetCart(long id)
    {
      try
      {
        var cartList = (from c in db.Carts.Where(e => e.User_ID==id && e.CartStatus_ID==45004)
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

    [HttpPost]
    [Route("api/PostItem")]
    public IHttpActionResult PostItem(Item item)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        db.Items.Add(item);
        db.SaveChanges();
        return Ok("Item Added Successfully");
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
    [Route("api/GetDetailsForCartPage/{username=username}")]
    public IHttpActionResult GetDetailsForCartPage(string username)
    {
      try
      {
        DataOperations op = new DataOperations();
        var result = op.GetCartDetails(username);
        return Ok(result);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/OrderConfirmation/{cartid=cartid}")]
    public IHttpActionResult GetOrderConfirmation(long cartid)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        DataOperations op = new DataOperations();
        var result = op.GetOrderDetails(cartid);
        return Ok(result);
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }
  }
}