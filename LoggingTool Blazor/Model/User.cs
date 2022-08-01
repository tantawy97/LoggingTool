

namespace LoggingTool.Model
{
    public class User
    {
        public string id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Login> Logins { get; set; }
    }
}
