using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;

namespace JWTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hello {currentUser.GivenName}, You are an {currentUser.Role}");
        }
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Authorized! You're on public method.");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }
    }
}
