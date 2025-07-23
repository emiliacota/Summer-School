namespace UserSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager userManager = new Manager("users.txt");
            userManager.LoadFromFile();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Show All Users");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        new RegistrationForm(userManager).Show();
                        break;
                    case "2":
                        new LoginForm(userManager).Show();
                        break;
                    case "3":
                        userManager.PrintAllUsers();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int id, string username, string password, string email)
        {
            ID = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Username: {Username}, Email: {Email}";
        }

        public string ToFileLine()
        {
            return $"{ID};{Username};{Password};{Email}";
        }

        public static User FromFileLine(string line)
        {
            string[] parts = line.Split(';');
            return new User(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                parts[3]
            );
        }
    }

    class RegistrationForm
    {
        private Manager manager;

        public RegistrationForm(Manager m)
        {
            manager = m;
        }

        public void Show()
        {
            Console.WriteLine("\n--- Register ---");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            if (Validate(username, password, email))
            {
                User newUser = new User(manager.GenerateId(), username, password, email);
                manager.AddUser(newUser);
                manager.SaveToFile();
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Validation failed. Try again.");
            }

            Close();
        }

        public bool Validate(string username, string password, string email)
        {
            if (username.Length < 3 || password.Length < 5 || !email.Contains("@"))
                return false;

            if (manager.UsernameExists(username))
                return false;

            return true;
        }

        public void Close()
        {
            Console.WriteLine("Exiting registration...");
        }
    }

    class LoginForm
    {
        private Manager manager;
        public User LoggedUser { get; private set; }

        public LoginForm(Manager m)
        {
            manager = m;
        }

        public void Show()
        {
            Console.WriteLine("\n--- Login ---");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (Validate(username, password))
            {
                Console.WriteLine($"Login successful! Welcome, {LoggedUser.Username}.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }

            Close();
        }

        public bool Validate(string username, string password)
        {
            LoggedUser = manager.FindUser(username, password);
            return LoggedUser != null;
        }

        public void Close()
        {
            Console.WriteLine("Exiting login...");
        }
    }

    class Manager
    {
        private List<User> users = new List<User>();
        private string filePath;

        public Manager(string file)
        {
            filePath = file;
        }

        public void LoadFromFile()
        {
            users.Clear();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    users.Add(User.FromFileLine(line));
                }
            }
        }

        public void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (User user in users)
            {
                lines.Add(user.ToFileLine());
            }
            File.WriteAllLines(filePath, lines);
        }

        public int GenerateId()
        {
            if (users.Count == 0)
                return 1;
            return users[users.Count - 1].ID + 1;
        }


        public void AddUser(User user)
        {
            users.Add(user);
        }

        public bool UsernameExists(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                    return true;
            }
            return false;
        }

        public User FindUser(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                    return user;
            }
            return null;
        }

        public void PrintAllUsers()
        {
            Console.WriteLine("\n--- Registered Users ---");
            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
