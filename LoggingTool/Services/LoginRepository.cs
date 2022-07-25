using AutoMapper;
using LoggingTool.Common;
using LoggingTool.Dtos;
using LoggingTool.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoggingTool.Services
{

    public class LoginRepository : ILoginRepository
    {
        private readonly LoggingToolContext db;
        SharedFunction sf = new SharedFunction();
        private readonly IMapper imapper;
        private readonly UserManager<User> usermanager;
        private readonly SignInManager<User> signInManager;

        public LoginRepository(LoggingToolContext db, IMapper imapper, UserManager<User> usermanager,SignInManager<User> signInManager)
        {
            this.db = db;
            this.imapper = imapper;
            this.usermanager = usermanager;
            this.signInManager = signInManager;
        }
        public async Task<List<LoginDetails>> GetAll()
        {
            var Logins = await db.Logins.ToListAsync();

            return imapper.Map<List<LoginDetails>>(Logins);
        }
        public void Add(LoginDetails loginDetails)
        {
            loginDetails.Password = sf.EncryptPassword(loginDetails.Password);
            var login = imapper.Map<Login>(loginDetails);
            db.Logins.Add(login);
            db.SaveChanges();
        }
        public void Edit(int id, LoginDetails loginDetails)
        {

            if (loginDetails != null)
            {
                loginDetails.Password = sf.EncryptPassword(loginDetails.Password);
                var oldLogin = db.Logins?.AsNoTracking().SingleOrDefault(w => w.Id == id);
                oldLogin = imapper.Map<Login>(loginDetails);
                oldLogin.Id = id;
                db.Update(oldLogin);
                db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var deleteLogin = db.Logins?.FirstOrDefault(w => w.Id == id);
            if (deleteLogin == null) { throw new Exception("Invalid Id"); }
            db.Logins.Remove(deleteLogin);
            db.SaveChanges();
        }

        public async Task<List<LoginDetails>> GetByUserId(string id)
        {
            var Logins = await db.Logins?.Where(w => w.UserId == id).ToListAsync();
            return imapper.Map<List<LoginDetails>>(Logins);
        }
    }
}
