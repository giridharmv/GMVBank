using GMVBank.DB;
using GMVBank.Models;

namespace GMVBank.Helpers
{
    public class DatabaseHelper
    {
        /// <summary>
        /// Saves a user to the database
        /// </summary>
        public static void SaveUser(User user)
        {
            using (Database db = new Database())
            {
                db.Database.EnsureCreated();
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine($"\n? User '{user.Name}' saved successfully! User ID: {user.Id}");
            }
        }

        /// <summary>
        /// Retrieves all users from the database
        /// </summary>
        public static List<User> GetAllUsers()
        {
            using (Database db = new Database())
            {
                db.Database.EnsureCreated();
                return db.Users.ToList();
            }
        }

        /// <summary>
        /// Finds a user by account number
        /// </summary>
        public static User? GetUserByAccountNumber()
        {
            Console.WriteLine("Please Enter Account Number:\n");
            string accountNumber = Console.ReadLine() ?? string.Empty;
            using (Database db = new Database())
            {
                db.Database.EnsureCreated();
                return db.Users.FirstOrDefault(u => u.AccountNumber == accountNumber);
            }
        }

        /// <summary>
        /// Displays all users in the database
        /// </summary>
        public static void DisplayAllUsers()
        {
            var users = GetAllUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("\nNo users found in database.");
                return;
            }

            Console.WriteLine("\n======= All Users =======");
            foreach (var user in users)
            {
                Console.WriteLine($"\nID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Account Number: {user.AccountNumber}");
                Console.WriteLine($"Created: {user.CreatedAt}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
