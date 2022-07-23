using LoggingTool.Dtos;
using LoggingTool.Helper;
using LoggingTool.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LoggingTool.Common
{
    public class SharedFunction
    {
       
        private readonly string  key = "adsa@@a";
        private readonly UserManager<User> userManager;
        private readonly JWT jwt;
        public SharedFunction()
        {

        }
        public SharedFunction(UserManager<User> userManager,  IOptions<JWT> jwt)
        {
            this.userManager = userManager;
            this.jwt = jwt.Value;
        }
       
        public  string EncryptPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + key));
        }
        public  string DencryptPassword(string encryptPassword)
        {
            var result = Encoding.UTF8.GetString(Convert.FromBase64String(encryptPassword));
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
        public async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
