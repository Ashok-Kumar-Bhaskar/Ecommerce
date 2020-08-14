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
    public class ProductController : ApiController
    {
    private ECommerceEntities db = new ECommerceEntities();

    [HttpGet]
    [Route("api/GetProduct")]
    public IHttpActionResult GetProduct()
    {
      try
      {
        List<Product> productList = new List<Product>();
        productList = db.Products.ToList();
        var ListOfProducts = (from p in db.Products.Where(e=> e.IsDeleted == false) join
                              i in db.Inventories on p.Product_ID equals i.Product_ID join
                              c in db.Categories on p.Category_ID equals c.Category_ID join
                              s in db.Sellers on i.Seller_ID equals s.Seller_ID
                              select new
                              {
                                p.Product_ID, p.Category_ID, p.Color,
                                p.Description, p.IsDeleted, p.ReorderQuantity, p.Variance,
                                p.ProductName, p.Image, p.Brand, i.Price, c.CategoryName, s.SellerName,
                                i.Commodity_ID, i.Stock
                              });
        return Ok(ListOfProducts);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/GetProductByCategory/{id=id}")]
    public IHttpActionResult GetProductByCategory(int id)
    {
      try
      {
        List<Product> productList = new List<Product>();
        productList = db.Products.ToList();
        var ListOfProducts = (from p in db.Products.Where(e=> e.IsDeleted == false) join
                              i in db.Inventories on p.Product_ID equals i.Product_ID join
                              c in db.Categories.Where(f => f.Category_ID == id) on p.Category_ID equals c.Category_ID join
                              s in db.Sellers on i.Seller_ID equals s.Seller_ID
                              select new
                              {
                                p.Product_ID, p.Category_ID, p.Color,
                                p.Description, p.IsDeleted, p.ReorderQuantity, p.Variance,
                                p.ProductName, p.Image, p.Brand, i.Price, c.CategoryName, s.SellerName,
                                i.Commodity_ID, i.Stock
                              });
        return Ok(ListOfProducts);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpPost]
    [Route("api/PostProduct")]
    [ResponseType(typeof(Product))]
    public IHttpActionResult PostProduct(Product product)         //Add new Product Detail
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        
          db.Products.Add(product);
          db.SaveChanges();
          return Ok("Product Added Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

    [HttpPut]
    [Route("api/PutProduct/{id=id}")]
    public IHttpActionResult PutProduct(int id, Product product)    //Modify Product
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

          var prod = db.Products.FirstOrDefault(e => e.Product_ID == id);

          if (prod == null)
          {
            return NotFound();
          }
          else 
          {
          prod.Category_ID = product.Category_ID;
          prod.Brand = product.Brand;
          prod.ProductName = product.ProductName;
          prod.Variance = product.Variance;
          prod.Color = product.Color;
          prod.Description = product.Description;
          prod.ReorderQuantity = product.ReorderQuantity;
          prod.Image = product.Image;
          db.SaveChanges();

          return Ok("Product has been Updated");
          }
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/GetProductForProductPage")]
    public IHttpActionResult GetProductForProductPage()
    {
      try
      {
        DataOperations op = new DataOperations();
        var result = op.GetProductsForHomePage();
        return Ok(result);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpGet]
    [Route("api/GetProductsInEachCategory")]
    public IHttpActionResult GetProductsInEachCategory(Category category)
    {
      try
      {
        DataOperations op = new DataOperations();
        var result = op.GetProductsForEachCategory(category);
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
