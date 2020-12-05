using IngeneosTest.Application.Contract;
using IngeneosTest.Application.Dto;
using IngeneosTest.Core.Helpers;
using IngeneosTest.Core.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IngeneosTest.Application.Services
{
    public partial class ManageService : IManageService
    {
        public  async Task<AuthenticationResult> LoginUser(User user)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(await HttpServiceClient.Get(fakeServiceUrlBase + "Users"));
            

            if(users.Count(p => p.UserName == user.UserName && p.Password == user.Password) > 0)
            {
                return GenerateAuthenticationResultForUserAsync(user);
            }
            else
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User doesn't exist." }
                };
            }
        }

        private AuthenticationResult GenerateAuthenticationResultForUserAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
