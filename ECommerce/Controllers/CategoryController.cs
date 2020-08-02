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
    }
}
