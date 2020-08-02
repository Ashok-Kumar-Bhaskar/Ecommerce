using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ECommerce.Models
{
  public class JWTContainerModel : IAuthContainerModel
  {
    #region --Methods--
    public int ExpireMinutes { get; set; } = 5;
    public string SecretKey { get; set; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
    public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
    public Claim[] Claims { get; set; }
    #endregion
  }
}