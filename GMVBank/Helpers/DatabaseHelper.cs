using GMVBank.DB;
using GMVBank.Models;
using GMVBank.Helpers;

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
                Console.WriteLine($"\n? User '{user.Name}' saved successfully! User ID: {user.CustomerID}");
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
        /// Finds a user by customer ID
        /// </summary>
        public static User? GetUserByCustomerID()
        {
            Console.WriteLine("Please Enter Customer ID:\n");
            int customerid = Convert.ToInt32(Console.ReadLine());
            Extension.Instance.EnsureIntegerInRange(customerid, 0, int.MaxValue);
            using (Database db = new Database())
            {
                db.Database.EnsureCreated();
                return db.Users.FirstOrDefault(u => u.CustomerID == customerid);
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
                Console.WriteLine($"\nID: {user.CustomerID}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Account Number: {user.AccountNumber}");
                Console.WriteLine($"Created: {user.CreatedAt}");
                Console.WriteLine("------------------------");
            }
        }
    }
}
