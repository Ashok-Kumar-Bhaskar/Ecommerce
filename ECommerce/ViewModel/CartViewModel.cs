using ECommerce.Models;
using System;

namespace ECommerce.ViewModel
{
  public class CartViewModel
  {
    public long User_ID { get; set; }    //Cart
    public long Cart_ID { get; set; }     //Car
    public long CartStatus_ID { get; set; }   //Cart
    public long Commodity_ID { get; set; }    //Inventory
    public int Quantity { get; set; }     //Items
    public decimal Price { get; set; }    //Items
    public string CartDescription { get; set; }   //CartStatus
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Variance { get; set; }
    public decimal Total { get; set; }
    public string Username { get; set; }

  }
}