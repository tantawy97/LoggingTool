using System.Text;

namespace LoggingTool.Common
{
    public class SharedFunction
    {
        private static string key = "adsa@@a";
        public static string EncryptPassword(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + key));
        }
        public static string DencryptPassword(string encryptPassword)
        {
            var result = Encoding.UTF8.GetString(Convert.FromBase64String(encryptPassword));
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }


    }
}
