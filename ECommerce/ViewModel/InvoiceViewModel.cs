using ECommerce.Models;
using System;

namespace ECommerce.ViewModel
{
  public class InvoiceViewModel
  {    
    public long Orders_ID { get; set; } 
    public long User_ID { get; set; }
    public DateTime OrdersDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public long InvoiceNumber { get; set; }
    public long Cart_ID { get; set; }
    public long Items_ID { get; set; }
    public long Commodity_ID { get; set; }
    public decimal Amount { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; }
    public string DeliveryAgentName { get; set; }
    public string PaymentMode { get; set; }
    public bool Paid { get; set; }
    public long Payment_ID { get; set; }

  }
}