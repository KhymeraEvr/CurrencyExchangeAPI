using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApplication1.Models.Authentication;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;        
        }

        [HttpPost("/loginToken")]
        public async Task<IActionResult> PostToken()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            var identity = await _userService.GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest();
            }

            var now = DateTime.UtcNow;            
            var jwt = new JwtSecurityToken(
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
       
            Response.ContentType = "application/json";
             return  Ok(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost]
        [Route("/registerToken")]
        public async Task<IActionResult> RegisterToken()
        {
            Console.WriteLine();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           // _userService.UnitOfWork.Users.Add(new User(){Login = model.Email,Password = model.Password,Role = "user"});
            return Ok();
        }


    }
}