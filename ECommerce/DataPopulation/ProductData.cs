using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.DataPopulation
{
  public class ProductData
  {
    #region [-- Properties --] 
    private IList<Product> m_ListProduct = new List<Product>();
    #endregion

    #region [-- Methods --]
    private void InitializeDataForProduct()
    {
      m_ListProduct = new List<Product>() {
                new Product(){ Category_ID = 1, Brand = "Poco", ProductName = "F1", Variance = "64GB + 6GB", Color = "Black",
                  Description = "4500 mAh", ReorderQuantity = 5, IsDeleted = false },
                new Product(){ Category_ID = 1, Brand = "Poco", ProductName = "F1", Variance = "64GB + 6GB", Color = "Blue",
                  Description = "4500 mAh", ReorderQuantity = 5, IsDeleted = false}
      };
    }

    public IEnumerable<Product> ReturnListDataForProduct()
    {
      return m_ListProduct.ToList();
    }
    #endregion

    #region [-- Constructor --]
    public ProductData()
    {
      InitializeDataForProduct();
    }
    #endregion
  }
}