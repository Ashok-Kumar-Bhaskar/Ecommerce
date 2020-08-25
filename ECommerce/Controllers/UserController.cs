using ECommerce.DBOperations;
using ECommerce.Helper_Classes;
using ECommerce.HelperClasses;
using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Linq;
using System.Web.Http;

namespace ECommerce.Controllers
{
    public class UserController : ApiController
    {
    private ECommerceEntities db = new ECommerceEntities();

    [HttpGet]
    [Route("api/GetUser/{id=id}")]
    public IHttpActionResult GetUser(long id)
    {
      try
      {
        DataOperations op = new DataOperations();
        var result = op.GetUserDetails(id);

        return Ok(result.ToList());
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return BadRequest();
      }
    }

    [HttpPost]
    [Route("api/PostUser")]
    public IHttpActionResult PostUser(User user)
    {
      Login l = new Login();
      try
      {
        if (!ModelState.IsValid || l.IsUsernameExist(user.Username))
        {
          return BadRequest(ModelState);
        }

        user.Password = PasswordHash.GenerateHash(user.Password);

        db.Users.Add(user);
        db.SaveChanges();
        return Ok("User Added Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

    [HttpPut]
    [Route("api/ChangeUserRole/{id=id}")]
    public IHttpActionResult ChangeUserRole(long id, UserViewModel user)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var list = db.Users.FirstOrDefault(e => e.User_ID == id);

        if (list == null)
        {
          return NotFound();
        }

        else
        {
          list.Role = user.Role;
          db.SaveChanges();
        }

        return Ok("User Role Updated Successfully");
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }
  }
}
