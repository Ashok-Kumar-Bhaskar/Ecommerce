
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
    [Route("api/PostCart/{id=id}")]
    public IHttpActionResult PostCart(long id)
    {
        try
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          var cart = new Cart();
          cart.User_ID = id;
          cart.CartStatus_ID = 45004;

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
    public IHttpActionResult PutCart(long id)
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
          list.CartStatus_ID = 45001;
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

    [HttpGet]
    [Route("api/GetItemsDetails/{id=id}")]
    public IHttpActionResult GetItemsDetails(long id)
    {
      try
      {
        var itemList = (from c in db.Carts.Where(e => e.Cart_ID == id) join
                        i in db.Items on c.Cart_ID equals i.Cart_ID
                        select new
                        {
                          i.Items_ID, i.Quantity, i.Commodity_ID
                        });

        return Ok(itemList.ToList());
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpPut]
    [Route("api/PutItem/{id=id}")]
    public IHttpActionResult PutItem([FromUri()] long id, [FromBody()] int qty)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var list = db.Items.FirstOrDefault(e => e.Items_ID == id);

        if (list == null)
        {
          return NotFound();
        }

        else
        {
          list.Quantity = list.Quantity + qty;
          db.SaveChanges();
        }

        return Ok("Item Updated Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

    [HttpDelete]
    [Route("api/DeleteItem/{id=id}")]
    public IHttpActionResult DeleteItem(long id)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        Item item = db.Items.Find(id);

        if (item == null)
        {
          return NotFound();
        }

        else
        {
          db.Items.Remove(item);
          db.SaveChanges();
        }

        return Ok("Item Deleted Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

  }
}