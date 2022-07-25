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
         SharedFunction sf=new SharedFunction();
        private readonly IMapper imapper;

        public LoginRepository(LoggingToolContext db, IMapper imapper)
        {
            this.db = db;
            this.imapper = imapper;
           
        }
        public async Task<List<LoginDetails>> GetAll()
        {
            var Logins =await  db.Logins.ToListAsync();
            
            return imapper.Map<List<LoginDetails>>(Logins);
        }
        public void Add(LoginDetails loginDetails)
        {
            loginDetails.Password = sf.EncryptPassword(loginDetails.Password);
            var login = imapper.Map<Login>(loginDetails);
            db.Logins.Add(login);
            db.SaveChanges();
        }
        public  void Edit(int id,LoginDetails loginDetails)
        {

            if (loginDetails != null)
            {
                loginDetails.Password= sf.EncryptPassword(loginDetails.Password);
                var oldLogin = db.Logins?.AsNoTracking().SingleOrDefault(w=>w.Id==id);
                oldLogin = imapper.Map<Login>(loginDetails);
                oldLogin.Id = id;
                db.Update(oldLogin);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteLogin = db.Logins?.FirstOrDefault(w => w.Id == id);
            if (deleteLogin == null) { throw new Exception("Invalid Id") ; }
            db.Logins.Remove(deleteLogin);
            db.SaveChanges();
        }
    }
}
