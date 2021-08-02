using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace OpenOsp.Api.Services {

  public class UserClaimsService : IUserClaimsService {

    public UserClaimsService(IHttpContextAccessor accessor) {
      var id = accessor.HttpContext?.User.Claims
        .SingleOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
      UserId = Int32.Parse(id);
    }

    public int UserId { get; private set; }

  }

}