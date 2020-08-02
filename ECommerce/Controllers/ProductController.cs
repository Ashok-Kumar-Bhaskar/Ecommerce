﻿using ECommerce.HelperClasses;
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
        var ListOfProducts = (from p in db.Products
                              select new
                              {
                                p.Product_ID,
                                p.ProductName, p.Image, p.Brand
                              });
        return Ok(ListOfProducts.ToList());
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
        List<ProductViewModel> productList = new List<ProductViewModel>();
        var ListOfProductsForProductPage = (from i in db.Inventories
                                            join p in db.Products on i.Product_ID equals p.Product_ID
                                            join s in db.Sellers on i.Seller_ID equals s.Seller_ID
                  
                                            select new
                                    {
                                      p.Product_ID, p.ProductName, p.Image, p.Brand, p.Color, p.Variance, s.SellerName, i.Commodity_ID, i.Price, i.Stock
                                    });
        foreach (var list in ListOfProductsForProductPage)
        {
          ProductViewModel productvm = new ProductViewModel();
          productvm.Product_ID = list.Product_ID;
          productvm.ProductName = list.ProductName;
          productvm.Image = list.Image;
          productvm.Brand = list.Brand;
          productvm.Color = list.Color;
          productvm.Variance = list.Variance;
          productvm.SellerName = list.SellerName;
          productvm.Commodity_ID = list.Commodity_ID;
          productvm.Price = list.Price;
          productvm.Stock = list.Stock;
          productList.Add(productvm);
        }
        return Ok(productList);
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }
  }
}
