using LoggingTool.Common;
using LoggingTool.Dtos;
using LoggingTool.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace LoggingTool.Services
{
    public class UserRepository : IUserRepository
    {
         SharedFunction sf=new SharedFunction();

        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
          
            _userManager = userManager;
        }
        public async Task<AuthDto> Login(LoginDto Login)
        {
            var authModel = new AuthDto();

            var user = await _userManager.FindByEmailAsync(Login.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, Login.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await sf.CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;


        }

        public Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }

       
    }
}
