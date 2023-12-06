using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using Entities;
namespace RacoonCore.Controllers    
{
    [RacoonCore.Controllers.Filter.Authorize("Admin"), RacoonCore.Controllers.Filter.Authorize("superAdmin")]
    public class AuthorizedController : BaseController
    {
        public Entities.Team CurrentUser
        {
            get
            {
                var userIdClaim = User.FindFirst("CustomerID");
                var userEncryptedIdClaim = User.FindFirst("CustomerEncryptedId");
                var userEmailClaim = User.FindFirst("CustomerEmail");
                var userRoleClaim = User.FindFirst(ClaimTypes.Role);
                var account = new Entities.Team
                {
                    Id = Int32.Parse(userIdClaim.Value),
                    EncryptedId = userEncryptedIdClaim.ToString(),
                    Email = userEmailClaim.ToString(),
                    Role = userRoleClaim.ToString(),
                };
                return account;
            }
        } 
    }
}
