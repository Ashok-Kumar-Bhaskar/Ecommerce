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
    [Route("api/GetUser")]
    public IHttpActionResult GetUser()
    {
      try
      {
        var userList = (from u in db.Users join
                        p in db.Preferences on u.User_ID equals p.User_ID join
                        t in db.Themes on p.Theme_ID equals t.Theme_ID

                        select new
                        {
                          u.User_ID,
                          u.FirstName,
                          u.LastName,
                          u.Email,
                          u.Username,
                          u.Password,
                          u.DefaultContact,
                          u.Role,
                          t.ThemeName
                          
                        });

        return Ok(userList.ToList());
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
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

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
