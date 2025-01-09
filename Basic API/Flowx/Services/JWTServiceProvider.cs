using Backend1.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Backend1.Services
{
    public static class JWTServiceProvider
    {
        // create a secreat key
        public static string GenerateToken(string name , string role)
        {
            byte[] key = Encoding.UTF8.GetBytes("Meet-Joshis-super-secure-secret-key-Meet-Joshis-super-secure-secret-key"); //JWT needs byte arry of key to create token

            // Token descripter:
            /* 
            Defines the structure of the JWT being created.

            Includes properties like

            Subject(ClaimsIdentity): Holds the claims(e.g., username). // basically the data we want to store in token

            Expires: Defines the token's expiration time. 

            SigningCredentials: Specifies how the token will be signed (ie with what aglo and key)
            */

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName", name),
                    new Claim("UserRole", role)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Made 1 hour from now
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature) // we tell which algo to use and key
            };

            // so basically from this token has 3 part (JWT = A.B.C )

            // header which is provided by SecurityTokenDescriptor itself ({type:'jwt',algo:'HmacSha256Signature'}) --> converted to base64Url encoding = A

            // payload : the data and token meta data that we provide ie expiry date , user info  --> converte to base64url encoding = B

            // singnature: (header + payload) is encyted using key = C


            //Now we need object of tokenHandler class to create the token

            JwtSecurityTokenHandler th = new JwtSecurityTokenHandler();

            SecurityToken token = th.CreateToken(tokenDescriptor);

            return th.WriteToken(token);
        }

        public static TokenDetails ValidateTokenAndGetClaim(string token)
        {
            byte[] key = Encoding.UTF8.GetBytes("Meet-Joshis-super-secure-secret-key-Meet-Joshis-super-secure-secret-key"); //JWT needs byte arry of key to create token
            ClaimsPrincipal pricipal = ExtractPrinipal(token, key);

            TokenDetails user = new TokenDetails();
            user.Name = pricipal.FindFirst("UserName")?.Value;
            // Validate the Role claim
            user.Role = pricipal.FindFirst("UserRole")?.Value??"0";

            return user;
        }

        private static ClaimsPrincipal ExtractPrinipal(string token, byte[] key)
        {
            try
            {
                //Steps for this process

                // Make rule for validation

                // Use JWTTOkenHandler calss to validate token based on rules

                TokenValidationParameters validationParameters = new TokenValidationParameters    // Define the token validation parameters
                {
                    ValidateIssuer = false, // Skip issuer validation (can be added if needed)
                    ValidateAudience = false, // Skip audience validation (can be added if needed)
                    ValidateLifetime = true, // Ensure token is not expired
                    ValidateIssuerSigningKey = true, // Validate the signing key

                    // Provide the same key used to sign the token
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                // Create a token handler
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken ValidatedToken);

                return principal;
            }
            catch (Exception ex)
            {
                // Handle validation failure (e.g., log error)
                throw new SecurityTokenException("Token validation failed: " + ex.Message+"\n So You are not authorized to come here");
            }
        }
    }
}