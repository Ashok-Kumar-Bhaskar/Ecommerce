using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ECommerce.Controllers
{
    public class CategoryController : ApiController
    {
      private ECommerceEntities db = new ECommerceEntities();
      
      [HttpGet]
      [Route("api/GetCategory")]
      public IHttpActionResult GetCategory()
      {
      try {
        List<Category> categoryList = new List<Category>();
        categoryList = db.Categories.ToList();
        var ListOfCategory = (from cat in db.Categories 
          select new
          {
            cat.CategoryName,
            cat.Category_ID
          });
        return Ok(ListOfCategory.ToList());
      }

      catch(Exception e) {
        LogFile.WriteLog(e);
        return BadRequest(); }
      }

    [HttpGet]
    [Route("api/GetSeller")]
    public IHttpActionResult GetSeller()
    {
      try
      {
        List<Seller> sellerList = new List<Seller>();
        sellerList = db.Sellers.ToList();
        var ListOfSeller = (from s in db.Sellers
                              select new
                              {
                                s.SellerName,
                                s.Seller_ID
                              });
        return Ok(ListOfSeller.ToList());
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpPost]
    [Route("api/PostCategory")]
    public IHttpActionResult PostCategory(Category category)
    {
      try
      {
        Category cat = new Category();
        cat.CategoryName = category.CategoryName;
        cat.IsDeleted = category.IsDeleted;

        db.Categories.Add(cat);
        db.SaveChanges();
        return Ok(cat);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    
  }
}
