using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Services
{
    public interface ILoginRepository
    {
        Task<List<LoginDetails>> GetAll();
        Task<List<LoginDetails>> GetByUserId(string Id);
        void Edit(int id,LoginDetails loginDetails);
        void Add(LoginDetails loginDetails);
        void Delete(int id);
    }
}
