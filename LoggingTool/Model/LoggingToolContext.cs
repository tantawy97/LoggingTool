using LoggingTool.Helper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoggingTool.Model
{
    public class LoggingToolContext: IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }


        public LoggingToolContext(DbContextOptions<LoggingToolContext> options) : base(options)
        {
        }
       
    }

   
}
