using ECommerce.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.UnitTests.Controllers
{
  [TestFixture]
  public class CartControllerTests
  {
    [Test]
    public void CheckWhetherCartDetailsIsGenerated()
    {
      CartController controller = new CartController();

      var result = controller.GetDetailsForCartPage();

      Assert.IsNotNull(result);
    }
  }
}
