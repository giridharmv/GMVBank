using GMVBank.DB;
using GMVBank.Helpers;
using GMVBank.Models;
using System.Xml.Serialization;

namespace GMVBank
{
    public class Program
    {
        #region Main Method
        static void Main()
        {
            Console.WriteLine("************* WELCOME TO GMVBANK *************");

            UserOperationOptions(); // Call the method to display user operation options
        }
        #endregion

        /// <summary>
        /// This method displays the user operation options and takes the user's choice as input.
        /// </summary>
        private static void UserOperationOptions()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Please select an option:");
            Console.WriteLine(string.Join("\n", OptionHelper.UserOperationOptions.Keys.Select(key => $"{key}. {OptionHelper.UserOperationOptions[key]}")));
            int choice = Convert.ToInt32(Console.ReadLine());
            if(!(choice <= OptionHelper.UserOperationOptions.Count))
                throw new Exception("Invalid choice. Please select a valid option.");
            GetUserChoice(choice);
            UserOperationOptions(); // Call UserOperationOptions method again to display the options after performing the action
        }

        /// <summary>
        /// This method takes the user's choice as input and performs the corresponding action based on the choice.
        /// </summary>
        /// <param name="choice"></param>
        private static void GetUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Program p = new();
                    p.CreateNewAccount();
                    break;
                case 2:
                    Console.WriteLine("Deposit Money");
                    break;
                case 3:
                    Console.WriteLine("Withdraw Money");
                    break;
                case 4:
                    Console.WriteLine("Check Balance");
                    break;
                case 5:
                    User? userbyAcc = DatabaseHelper.GetUserByAccountNumber();
                    if (userbyAcc != null)
                    {
                        Console.WriteLine($"User Name: {userbyAcc.Name}");
                        Console.WriteLine($"Account Number: {userbyAcc.AccountNumber}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                        break;
                    }
                case 6:
                    Console.WriteLine("All Users Account Numbers....");
                    DatabaseHelper.DisplayAllUsers();
                    break;
                case 7:
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
            }
        }

        /// <summary>
        /// This method creates a new account by collecting user details and saving them to the database.
        /// </summary>
        private void CreateNewAccount()
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
                    Gender = GetUserDetails.Instance.Gender
                };
                // Add user to database
                db.Users.Add(user);

                // Save changes to database
                db.SaveChanges();

                Console.WriteLine("\n✓ User data saved successfully to database!");
            }
        }
        /// <summary>
        /// This method updates the UserDetails by calling the GetUserDetails methods for getting user details.
        /// </summary>
        public void UserDetails()
        {
            GetUserDetails.Instance.GetUserName();
            GetUserDetails.Instance.GetUserAccountNumber();
            GetUserDetails.Instance.GetUserAccountType();
            GetUserDetails.Instance.GetUserGender();
        }
    }
}
