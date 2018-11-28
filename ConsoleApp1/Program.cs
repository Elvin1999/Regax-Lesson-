using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public void ShowUserProperty()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Username - >{Username}");
            Console.Write($"Password - >");
            for (int i = 0; i < Password.Length; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    class Controller
    {
        JsonSerializer json = new JsonSerializer();
        List<User> users = new List<User>();
        public Controller()
        {
            FileInfo fi = new FileInfo("list5.json");
            if (!fi.Exists)
            {
                SerializerToJSON();
            }
        }
        public User SignUp()
        {
            string username; string password; List<User> item;
            do
            {
                Console.Write("Username - >");
                username = Console.ReadLine();
                item = users.Where(x => x.Username == username).ToList();
                if (item.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This \"Username\" is already exist");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (!CheckUsername(username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username must have at least one \"Uppercase letter and symbol\"\n" +
                        "letters' count must be equal 10");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            } while (!((CheckUsername(username))&& item.Count == 0));
            do
            {
                Console.Write("Password - >");
                password = Console.ReadLine();
                if (!CheckPassword(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password letters' count must be greater than 8 and at least one \"Uppercase letter\"");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            } while (!CheckPassword(password));
            return new User(username, password);
        }
        public bool CheckUsername(string username)
        {
            Regex name = new Regex(@"^[A-Z]{1}?[a-zA-Z0-9]{8}?[!-/_]{1}");
            if (name.IsMatch(username))
            {
                return true;
            }
            return false;//test
        }
        public bool CheckPassword(string password)
        {
            Regex pass = new Regex(@"^[A-Z]{1}?[a-zA-Z0-9]{7}?");
            if (pass.IsMatch(password))
            {
                return true;
            }
            return false;//test
        }
        public void SerializerToJSON()
        {
            using (StreamWriter sw = new StreamWriter("list5.json"))
            {
                json.Serialize(sw, users);
                //sw.WriteLine(json);
            }
        }
        public List<User> DeserializerFromJASON()
        {
            List<User> result;
            using (StreamReader sr = new StreamReader("list5.json"))
            {
                string str = sr.ReadToEnd();
                // var mylist = json.Deserialize(str);
                List<User> items = JsonConvert.DeserializeObject<List<User>>(str);
                result = items;
            }
            return result;
        }
        public void run()
        {
            //Console.WriteLine(Name.IsMatch("Audfgjka_"));
            //Console.WriteLine(pass.IsMatch("123456798798"));
            User user;
            Console.WriteLine("SIGN UP 3  SIGN IN 4");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 3)
            {
                users = DeserializerFromJASON();
                user = SignUp();
                users.Add(user);
                SerializerToJSON();
            }
            else if (selection == 4)
            {

            }
            Console.WriteLine("Show all users select 1 no 2");
            selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                users = DeserializerFromJASON();
                foreach (var item in users)
                {
                    item.ShowUserProperty();
                }
            }
            //else if (selection == 2)
            //{
            //}

        }

        /////
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

