namespace LoggingTool.Model
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public virtual User User { get; set; }
    }
}
