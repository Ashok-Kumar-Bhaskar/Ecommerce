using ECommerce.Models;
using System.Collections.Generic;

namespace ECommerce.ViewModel
{
  public class SearchResultsViewModel
  {
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string SellerName { get; set; }
    public List<long> ProductID { get; set; }
    public List<long> CategoryID { get; set; }
  }
}