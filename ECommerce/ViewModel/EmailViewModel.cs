using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
  public class EmailViewModel
  {
    public int Quantity { get; set; }     //Items
    public decimal Amount { get; set; }    //Items
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Variance { get; set; }
   
   
  }
}