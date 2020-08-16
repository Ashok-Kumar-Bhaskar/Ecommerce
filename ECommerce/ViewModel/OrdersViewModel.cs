using ECommerce.Models;
using System;

namespace ECommerce.ViewModel
{
  public class OrdersViewModel
  {
    public long Cart_ID { get; set; }
    public long Orders_ID { get; set; }
    public long User_ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string Variance { get; set; }
    public string Color { get; set; }
    public long Payment_ID { get; set; }
    public long Commodity_ID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public long Items_ID { get; set; }
    public bool Paid { get; set; }
    public string PaymentMode { get; set; }
    public string ShipmentAgent { get; set; }
    public string OrderStatus { get; set; }
    public DateTime Date { get; set; }

  }
}