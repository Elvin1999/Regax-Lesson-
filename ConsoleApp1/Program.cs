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
    class User
    {
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
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
    }
    class Controller
    {
        JsonSerializer json = new JsonSerializer();
        List<User> users = new List<User>();
        public User SignUp()
        {
            string username; string password;
            do
            {
                Console.Write("Username - >");
                username = Console.ReadLine();
            } while (!CheckUsername(username));
            do
            {
                Console.Write("Password - >");
                password = Console.ReadLine();

            } while (!CheckPassword(password));
            return new User(username, password);
        }
        public bool CheckUsername(string username)
        {
            Regex name = new Regex(@"^[A-Z]{1}?[a-zA-Z]{7}?[!-/_]{1}");
            if (name.IsMatch(username))
            {
                return true;
            }
            return true;//test
        }
        public bool CheckPassword(string password)
        {
            Regex pass = new Regex(@"^[a-zA-Z0-9]{8}?");
            if (pass.IsMatch(password))
            {
                return true;
            }
            return true;//test
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
            Console.WriteLine("For registreation select 3");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 3)
            {
                users = DeserializerFromJASON();              
                user = SignUp();
                users.Add(user);
                SerializerToJSON();
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
            else if (selection == 2) { 
}

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
