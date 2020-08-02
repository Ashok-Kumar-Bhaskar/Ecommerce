using ECommerce.Models;
using System;

namespace ECommerce.ViewModel
{
  public class CartViewModel
  {
    public long User_ID { get; set; }    //Cart
    public long Cart_ID { get; set; }     //Cart
    public DateTime CartDate { get; set; }  //Cart
    public long CartStatus_ID { get; set; }   //Cart
    public long Commodity_ID { get; set; }    //Inventory
    public int Quantity { get; set; }     //Items
    public decimal Price { get; set; }    //Items
    public int Stock { get; set; }    //Inventory
    public string CartDescription { get; set; }   //CartStatus
  }
}