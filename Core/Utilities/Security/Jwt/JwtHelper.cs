using Core.Entities.Concrete;
using Core.Utilities.Security.Encyription;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: operationClaims,
                signingCredentials: signingCredentials

                );
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim>operationClaims)
        {
            var claims= new List<Claim>();
            claims.Add(new Claim("email", user.Email));

            return null;
        }
    }
}
