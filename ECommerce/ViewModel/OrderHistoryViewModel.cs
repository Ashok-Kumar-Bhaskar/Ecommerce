using ECommerce.Models;

namespace ECommerce.ViewModel
{
  public class OrderHistoryViewModel
  {
    public Order Order { get; set; }
    public Invoice Invoice { get; set; }
  }
}