using ECommerce.Controllers;
using ECommerce.DBOperations;
using ECommerce.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ECommerce.UnitTests.Controllers
{
  [TestFixture]
  public class TokenControllerTests
  {
    private ECommerceEntities db = new ECommerceEntities();
    [TestCase("Admin","password")]
    public void CheckWhetherTokenIsGenerated(string username, string password)
    {
      Login login = new Login();
      login.userName = username;
      login.password = password;
      TokenController tc = new TokenController();
      var result = tc.GetToken(login);
      Console.WriteLine(result);
      Assert.IsNotNull(result);
    }
  }
}
