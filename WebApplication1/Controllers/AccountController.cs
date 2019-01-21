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
        public async Task<IActionResult> PostToken([FromBody] LoginModel model)
        {
            var username = model.Email;
            var password = model.Password;

            var identity = await _userService.GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest();
            }
            Response.ContentType = "application/json";
            return Ok(_userService.GetToken(identity));
        }

        [HttpPost]
        [Route("/registerToken")]
        public async Task<IActionResult> RegisterToken([FromBody] RegisterModel model)
        {
            Console.WriteLine();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (! await _userService.UserNameIsAvailable(model.Email)) return BadRequest();
            string role = "user";
            if (model.Email.EndsWith("eleks.com"))
            {
                role = "admin";
            }
            await _userService.UnitOfWork.Add(new User() { Login = model.Email, Password = model.Password, Role = role });
            
            var username = model.Email;
            var password = model.Password;
            var identity = await _userService.GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest();
            }
            Response.ContentType = "application/json";
            var token = _userService.GetToken(identity);
            return Ok(token);
        }

    }
}