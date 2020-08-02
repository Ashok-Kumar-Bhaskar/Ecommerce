using ECommerce.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UnitTests.Controllers
{
  [TestFixture]
  public class UserControllerTests
  {
    [Test]
    public void WhetherUserDetailsIsReturned()
    {
      UserController controller = new UserController();

      var result = controller.GetUser();

      Assert.IsNotNull(result);
    }
  }
}
