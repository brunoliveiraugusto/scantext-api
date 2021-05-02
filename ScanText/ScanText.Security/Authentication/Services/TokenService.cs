using ScanText.Security.Authentication.Entities;
using ScanText.Security.Authentication.Interfaces;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ScanText.Security.Authentication.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenSettings _token;
        private readonly IHttpContextAccessor _acessor;

        public TokenService(ITokenSettings token, IHttpContextAccessor acessor)
        {
            _token = token;
            _acessor = acessor;
        }

        public string GenerateSimpleToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(UsuarioAuthentication usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Role, usuario.Role),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            SetIdentityUser(tokenDescriptor.Subject, tokenDescriptor.Subject.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray());

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void SetIdentityUser(IIdentity identity, string[] roles)
        {
            GenericPrincipal principal = new GenericPrincipal(identity, roles);
            _acessor.HttpContext.User = principal;
        }
    }
}
