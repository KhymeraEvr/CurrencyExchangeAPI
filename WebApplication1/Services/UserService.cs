using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Models.Authentication;
using WebApplication1.Models.DbContexts;
using WebApplication1.Models.UnitOfWork;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            User person = await UnitOfWork.Users.FindFirst(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

        public string GetToken(ClaimsIdentity identity)
        {

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
                username = identity.Name,             
                role = identity.Claims.FirstOrDefault(cl=>cl.Type == ClaimTypes.Role).Value
            };


            return JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        public async Task<bool> UserNameIsAvailable(string name)
        {
            var checkUser = await UnitOfWork.Users.FindFirst(x => x.Login == name);
            return  checkUser == null;
        }
    }
}
