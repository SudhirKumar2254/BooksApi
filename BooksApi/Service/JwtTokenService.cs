using BooksApi.Authentication;
using BooksApi.Service.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BooksApi.Service
{
    public class JwtTokenService:IJwtTokenService
    {
        private readonly JWTSettings _jwtSettings;

        public JwtTokenService(IOptions<JWTSettings> jwtSettings)
            {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
        //Check the user email if valid - authenticate from anywhere you want
          
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(request.Email);
            AuthenticationResponse response = new AuthenticationResponse();            
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = request.Email;
            //  var refreshToken = GenerateRefreshToken(ipAddress);
            // response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"Authenticated {request.Email}");
        }
        private async Task<JwtSecurityToken> GenerateJWToken(string email)
        {
            //Check user claims and roles
            //var userClaims = await _userManager.GetClaimsAsync(user);
            //var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Email, email)
            };            

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        //private RefreshToken GenerateRefreshToken(string ipAddress)
        //{
        //    return new RefreshToken
        //    {
        //        Token = RandomTokenString(),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Created = DateTime.UtcNow,
        //        CreatedByIp = ipAddress
        //    };
        //}

    }
}
