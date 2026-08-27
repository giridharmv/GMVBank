using GMVBank.DB;
using GMVBank.Models;
using System.Security.Cryptography;

namespace GMVBank.Helpers.ActionHelper
{
    public class CreateNewAccountHelper
    {
        /// <summary>
        /// This method creates a new account by collecting user details and saving them to the database.
        /// </summary>
        public void CreateNewAccount()
        {
            UserDetails(); // Call the UserDetails method to get user details
            using (Database db = new())
            {
                // Ensure database is created
                db.Database.EnsureCreated();

                // Create a new user from the collected data
                var user = new User
                {
                    Name = GetUserDetails.Instance.Name,
                    AccountNumber = GetUserDetails.Instance.AccountNumber,
                    AccountType = GetUserDetails.Instance.AccountType,
                    Gender = GetUserDetails.Instance.Gender,
                    CustomerID = GetUserDetails.Instance.CustomerID,
                };
                if (string.IsNullOrWhiteSpace(user.AccountType))
                {
                    throw new InvalidOperationException("Account type was not captured.");
                }
                // Add user to database
                db.Users.Add(user);

                // Save changes to database
                db.SaveChanges();

                Console.WriteLine($"\n✓ User data saved successfully to database! User ID: {user.CustomerID}");
            }
        }

        /// <summary>
        /// This method updates the UserDetails by calling the GetUserDetails methods for getting user details.
        /// </summary>
        public static void UserDetails()
        {
            GetUserDetails.Instance.GetUserName();
            GetUserDetails.Instance.AccountNumber = GetUserDetails.Instance.GetUserAccountNumber();
            GetUserDetails.Instance.GetUserAccountType();
            GetUserDetails.Instance.GetUserGender();
            GetUserDetails.Instance.CustomerID = GetUserDetails.Instance.GenerateCustomerId();
        }
    }
}
