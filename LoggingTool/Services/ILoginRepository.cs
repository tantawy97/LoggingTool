using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Services
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAll();
        void Edit(Login login);
        void Add(LoginDetails loginDetails);
        void Delete(int id);
    }
}
