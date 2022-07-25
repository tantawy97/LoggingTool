using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Services
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
       Task< AuthDto> SignIn(LoginDto user);
    }
}
