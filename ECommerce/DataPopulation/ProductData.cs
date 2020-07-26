﻿using ECommerce.Interfaces;
using ECommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataPopulation
{
  public class ProductData : IDataPopulation
  {
    #region [-- Properties --] 
    private IList<Product> m_ListProduct = new List<Product>();
    #endregion

    #region [-- Methods --]
    public void InitializeData()
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
      InitializeData();
    }
    #endregion
  }
}