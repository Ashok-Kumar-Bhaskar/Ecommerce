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
  public class ProductControllerTests
  {
    [Test]
    public void WhetherProductDetailsIsReturned()
    {
      ProductController controller = new ProductController();

      var result = controller.GetProductForProductPage();

      Assert.IsNotNull(result);
    }
  }
}
