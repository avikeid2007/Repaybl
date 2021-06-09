using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using RepayblApi.Core;
using RepayblApi.DTOs;
using RepayblApi.Models;

namespace RepayblApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : RepayblController
    {
        private readonly IConfiguration _configuration;
        public UserController(RepayblContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }
        private string GenerateJWT(Models.User user, DateTime expiry)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                new[] { new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                          new Claim(ClaimTypes.Uri,$"{ Request.Scheme}://{Request.Host}{Request.PathBase}/api/author/{user.Id}/thumbnail")
                },
                expires: expiry,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await Context.Users.SingleOrDefaultAsync(x => x.Email.Equals(request.UserName) && x.Password.Equals(request.Password));
            if (user is not null)
            {
                var expiry = DateTime.Now.AddDays(30);
                return GenerateJWT(user, expiry);
            }
            return null;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<LoginResult>> RegisterAsync(DTOs.User request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var dbUser = ConvertModels<Models.User, DTOs.User>(request);
            MapCreated(dbUser);
            await Context.Users.AddAsync(dbUser);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("CurrentUser")]

        public async Task<ActionResult<bool>> GetCurrentUserAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                return await Context.Users.AnyAsync(x => x.Email.Equals(email));
            }
            return false;
        }

    }
}
