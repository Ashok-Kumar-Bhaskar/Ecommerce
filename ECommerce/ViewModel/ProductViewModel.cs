using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
  public class ProductViewModel
  {
    public long Product_ID { get; set; }
    public long Commodity_ID { get; set; }
    public long Category_ID { get; set; }
    public string SellerName { get; set; }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string Image { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Variance { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public bool? isDeleted { get; set; }
    public int ReorderQuantity { get; set; }
    
  }
}