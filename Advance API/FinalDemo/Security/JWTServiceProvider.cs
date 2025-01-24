using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend1.Services
{
    public class TokenDetails
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }



    public static class JWTServiceProvider
    {
        // create a secreat key
        public static string GenerateToken(string name , string role)
        {
            byte[] key = Encoding.UTF8.GetBytes("Meet-Joshis-super-secure-secret-key-Meet-Joshis-super-secure-secret-key"); 

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