using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.Business.Interfaces;
using Store.Core.ViewEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/entity/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private IServiceRepository<AppUserModel> _service;
        private readonly ILogger<AuthenticateController> _log;
        private readonly IConfiguration Configuration;
        public AuthenticateController(IServiceRepository<AppUserModel> service,
            ILogger<AuthenticateController> log
            , IConfiguration configuration)
        {
            _service = service;
            _log = log;
            Configuration = configuration;
        }

        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="userParam">JSON App Details</param>
        /// <returns>Returns the new Entity document</returns>
        /// <returns>Returns 200 Fetch success</returns>
        /// <returns>Returns 401 Unauthorized error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AuthenticateUser([FromBody] AppUserModel userParam)
        {
            try
            {
                _log.LogInformation("{0} method of {1} started in Api at :\t{2}", "AuthenticateUser", "AuthenticateUserController", DateTime.UtcNow);
                if (!ModelState.IsValid) { return BadRequest(); }
                var result = _service.GetByCustom(userParam.LoginName + "#$#" + userParam.Password);
                if (result == null)
                    return Unauthorized();
                else
                {
                    var user = CreateToken(result);
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                _log.LogError("{0} occurred in {1} method of {2} in Api at :\t{3}", e, "AuthenticateUser", "AuthenticateUserController", DateTime.UtcNow);
                return NotFound();
            }
            finally
            {
                _log.LogInformation("{0} method of {1} ended in Api at :\t{2}", "AuthenticateUser", "AuthenticateUserController", DateTime.UtcNow);
            }
        }
        [NonAction]
        public AppUserModel CreateToken(AppUserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Authentication:JWTSecret").Value);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            // remove password before returning
            user.Password = null;
            return user;
        }
    }
}
