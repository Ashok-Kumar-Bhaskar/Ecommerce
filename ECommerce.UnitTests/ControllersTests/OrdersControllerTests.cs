using ECommerce.Controllers;
using ECommerce.Models;
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
  class OrdersControllerTests
  {
    private ECommerceEntities db = new ECommerceEntities();
    [TestCase(700002)]
    public void CheckWhetherInvoiceIsGenerated(long id)
    {
      // Set up Prerequisites   
      OrdersController controller = new OrdersController();
      // Act on Test  
      var response = controller.GetInvoice(id);
      // Assert the result  

      Console.WriteLine(response.ToString());
      Assert.IsNotNull(response.ToString());
    }

  }
}
