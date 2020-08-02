using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
  public class UserViewModel
  {
    public long User_ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public long DefaultContact { get; set; }
    public string Role { get; set; }
    public string Theme { get; set; }
  }
}