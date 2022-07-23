using AutoMapper;
using LoggingTool.Dtos;
using LoggingTool.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggingTool.Services
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LoggingToolContext db;
        private readonly IMapper mapper;

        public LoginRepository(LoggingToolContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public Task<List<Login>> GetAll()
        {
            return db.Logins.ToListAsync();
        }
        public void Add(LoginDetails loginDetails)
        {
            var loginData=mapper.Map<LoginDetails>(loginDetails);
            db.AddAsync(loginData);
            db.SaveChangesAsync();
        }
        public void Edit(Login login)
        {
        
            if(login != null)
            {

                db.Logins.Update(login);
            }
        }
        public void Delete(int id)
        {
            db.Logins.Remove(db.Logins.FirstOrDefault(w => w.Id == id));
            db.SaveChangesAsync();
        }
    }
}
