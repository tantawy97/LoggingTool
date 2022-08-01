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

        public  string EncryptPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + key));
        }
        public  string DecryptPassword(string encryptPassword)
        {
            var result = Encoding.UTF8.GetString(Convert.FromBase64String(encryptPassword));
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
       
    }
}
