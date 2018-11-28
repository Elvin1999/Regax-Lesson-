using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
    class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    class Controller
    {
        List<User> users = new List<User>();
        public void run()
        {
            Regex Name = new Regex(@"^[A-Z]{1}?[a-zA-Z]{7}?[!-/_]{1}");
            Regex pass = new Regex(@"^[a-zA-Z0-9]{8}?");
            Console.WriteLine(Name.IsMatch("Audfgjka_"));
            Console.WriteLine(pass.IsMatch("123456798798"));
        }
        public bool CheckUsername(string username)
        {
            return false;
        }
        public bool CheckPassword(string password)
        {
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          

            Controller controller = new Controller();
            controller.run();
        }
    }
}
