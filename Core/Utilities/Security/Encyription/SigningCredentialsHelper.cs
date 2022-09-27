using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encyription
{
    public class SigningCredentialsHelper
    {

        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        }



        //public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim>operationClaims)
        //{
        //    var jwt = new JwtSecurityToken(
        //        issuer:tokenOptions.Issuer,
        //        audience:tokenOptions.Audience,
        //        expires:tokenOptions.AccessTokenExpiration,
        //        notBefore:DateTime.Now,
        //        claims:operationClaims,
        //        signingCredentials:signingCredentials
                
        //        );
        //}
    }
}
