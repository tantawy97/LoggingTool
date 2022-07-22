using Microsoft.AspNetCore.Identity;

namespace LoggingTool.Model
{
    public class User :IdentityUser
    {
        public virtual List<Login> Logins { get; set; }
    }
}
