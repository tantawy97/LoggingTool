using AutoMapper;
using LoggingTool.Common;
using LoggingTool.Dtos;
using LoggingTool.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggingTool.Services
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LoggingToolContext db;
        private readonly IMapper imapper;

        public LoginRepository(LoggingToolContext db, IMapper imapper)
        {
            this.db = db;
            this.imapper = imapper;
        }
        public Task<List<Login>> GetAll()
        {
            return db.Logins.ToListAsync();
        }
        public void Add(LoginDetails loginDetails)
        {
            loginDetails.Password = SharedFunction.EncryptPassword(loginDetails.Password);
            var login = imapper.Map<Login>(loginDetails);
            db.Logins.AddAsync(login);
            db.SaveChangesAsync();
        }
        public void Edit(Login login)
        {

            if (login != null)
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
