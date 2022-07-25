namespace LoggingTool.Helper
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            User
        }
        public const string User_username = "user";
        public const string User_email = "user@gmail.com";
        public const string User_password = "Userpassword12";
        public const Roles User_role = Roles.User;

        public const string Admin_username = "admin";
        public const string Admin_email = "Admin@gmail.com";
        public const string Admin_password = "Adminpassword12";
        public const Roles Admin_role = Roles.Administrator;
    }
}

