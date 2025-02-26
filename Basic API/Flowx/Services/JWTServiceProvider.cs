using Backend1.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend1.Services
{
    public static class JWTServiceProvider
    {
        /*
         * 
         * A JWT (JSON Web Token) consists of 3 parts:
         * 1️ Header → Specifies the algorithm & type → Encoded as Base64Url (A)
         * 2️ Payload → Contains claims (user info & metadata) → Encoded as Base64Url (B)
         * 3️ Signature → HMACSHA256 (Header + Payload, Secret Key) → (C)
         *
         * Format:  A.B.C  ---> enitrly has expiry
         */

        //  Function to generate a JWT token for a given user
        public static string GenerateToken(string name, string role)
        {
            //  Secret key for signing the token (must be long & secure)
            byte[] key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["MySecretKey"]);


            //  Security Token Descriptor - Defines the structure & properties of the JWT
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName", name),  // Store username in token
                    new Claim("UserRole", role)   // Store user role in token
                }),
                Expires = DateTime.UtcNow.AddHours(1),  //  Token expires in 1 hour
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),  //  Sign token with secret key
                    SecurityAlgorithms.HmacSha256Signature  // Use HMAC SHA256 algorithm
                )
            };

            //  Create JWT Token using JwtSecurityTokenHandler
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            //  Convert token to string format & return
            return tokenHandler.WriteToken(token);
        }

        /*
         * Steps:
         * 1️ Decode the token.
         * 2️ Validate its authenticity using the secret key.
         * 3️ Extract user details (claims) if valid.
         */

        //  Function to validate a JWT token and extract user claims
        public static TokenDetails ValidateTokenAndGetClaim(string token)
        {
            //  Use the same secret key for validation
            byte[] key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["MySecretKey"]);

            // Extract claims if token is valid
            ClaimsPrincipal principal = ExtractPrincipal(token, key);

            // Store extracted user details
            TokenDetails user = new TokenDetails
            {
                Name = principal.FindFirst("UserName")?.Value,
                Role = principal.FindFirst("UserRole")?.Value ?? "0"  // Default role = 0 if missing
            };

            return user;
        }

        /*

         * Steps:
         *   Define validation rules (TokenValidationParameters)
         *   Use JwtSecurityTokenHandler to validate the token
         *   Extract ClaimsPrincipal from the validated token
         */

        private static ClaimsPrincipal ExtractPrincipal(string token, byte[] key)
        {
            try
            {
                //  Define rules for token validation
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,   //  No issuer validation (can be added if needed)
                    ValidateAudience = false, //  No audience validation (can be added if needed)
                    ValidateLifetime = true,  //   Ensure token is not expired
                    ValidateIssuerSigningKey = true, //   Validate signature using the secret key

                    IssuerSigningKey = new SymmetricSecurityKey(key) //  Use the same secret key
                };

                //  Validate token using JwtSecurityTokenHandler
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                return principal;
            }
            catch (Exception ex)
            {
                //  If validation fails, throw an exception
                throw new SecurityTokenException("Token validation failed: " + ex.Message + "\n  Unauthorized access.");
            }
        }
    }
}
