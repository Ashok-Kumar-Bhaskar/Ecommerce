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
  public class AddressControllerTests
  {
    [Test]
    public void WhetherAddressDetailsIsReturned()
    {
      AddressesController controller = new AddressesController();

      var result = controller.GetAddresses();

      Assert.IsNotNull(result);
    }
  }
}
