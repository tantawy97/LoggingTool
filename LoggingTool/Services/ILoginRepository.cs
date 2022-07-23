using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Services
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAll();
        void Edit(int id,LoginDetails loginDetails);
        void Add(LoginDetails loginDetails);
        void Delete(int id);
    }
}
