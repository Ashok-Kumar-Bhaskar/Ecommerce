using ECommerce.Authentication;
using ECommerce.DBOperations;
using ECommerce.HelperClasses;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ECommerce.Controllers
{
    public class TokenController : ApiController
    {
    [HttpPost]
    [Route("token")]
    public IHttpActionResult GetToken(Login login)
    {
      try
      {
        if (Login.LoginAttempt(login.userName, login.password, out User user) == "Successfull")
        {
          var roles = "user";
          if (user.Role == "Admin")
          {
            roles = "Admin";
          }

          IAuthContainerModel model = GetJWTContainerModel(user.Username, roles);
          IAuthService authService = new JWTService(model.SecretKey);

          string token = authService.GenerateToken(model);

          if (!authService.IsTokenValid(token))
            throw new UnauthorizedAccessException();
          else
          {
            List<Claim> claims = authService.GetTokenClaims(token).ToList();
          }
          return Ok(token);
        }
        else
        {
          return BadRequest("Invalid Credentials");
        }
      }
      catch (Exception ex)
      {
        LogFile.WriteLog(ex);
        return BadRequest();
      }
    }

      [NonAction]
      #region Private Methods
      private static JWTContainerModel GetJWTContainerModel(string username, string roles)
      {
        return new JWTContainerModel()
        {
          Claims = new Claim[]
          {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, roles)
          }
        };
      }
      #endregion
  }
}
