
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
        List<CartViewModel> cartList = new List<CartViewModel>();
        var ListOfProductsForCartPage = (from item in db.Items
                                         join i in db.Inventories on item.Commodity_ID equals i.Commodity_ID
                                         join c in db.Carts on item.Cart_ID equals c.Cart_ID
                                         join cs in db.CartStatus on c.CartStatus_ID equals cs.CartStatus_ID
                    

                                         select new
                                         { c.User_ID,
                                           c.Cart_ID,
                                           c.Date,
                                           i.Commodity_ID,
                                           item.Quantity,
                                           i.Price,
                                           cs.Description,
                                           i.Stock,
                                           c.CartStatus_ID
                                         });
        foreach (var list in ListOfProductsForCartPage)
        {
          CartViewModel cartvm = new CartViewModel();
          cartvm.User_ID = list.User_ID;
          cartvm.Cart_ID = list.Cart_ID;
          cartvm.Commodity_ID = list.Commodity_ID;
          cartvm.Quantity = list.Quantity;
          cartvm.Price = list.Price;
          cartvm.Stock = list.Stock;
          cartvm.CartStatus_ID = list.CartStatus_ID;
          //cartvm.CartDate = (DateTime)list.Date;
          cartvm.CartDescription = list.Description;
          cartList.Add(cartvm);
        }
        return Ok(cartList);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

  }
}