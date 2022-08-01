using LoggingTool.Dtos;
using LoggingTool.Model;

namespace LoggingTool.Services
{
    public interface ILoginRepository
    {
        Task<List<LoginDetailsDto>> GetAll();
        Task<List<LoginDetailsDto>> GetByUserId(string Id);
        void Edit(int id,LoginDetailsDto loginDetails);
        LoginDetailsDto GetbyId(int id);
        void Add(LoginDetailsDto loginDetails);
        void Delete(int id);
    }
}
