using GMVBank.Interface;
using GMVBank.Models;

namespace GMVBank.Helpers
{
    public class GetUserDetails: IUserData
    {
        #region Singleton Implementation
        private static GetUserDetails _instance = new GetUserDetails();
        public static GetUserDetails Instance => _instance;
        public GetUserDetails() { }
        #endregion

        #region Private Fields

        int _customerid = 0;
        string _userAccType = "Current Account";
        string _userGender = "male";
        string _name = "Giri";
        string _accountNumber = "912837483";
        public string AccountType
        {
            get => _userAccType;
            set => _userAccType = value;
        }
        public int CustomerID
        {
            get => _customerid;
            set => _customerid = value;
        }
        public string Gender
        {
            get => _userGender;
            set => _userGender = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string AccountNumber
        {
            get => _accountNumber;
            set => _accountNumber = value;
        }
        #endregion

        #region User Account Number
        /// <summary>
        /// Gets the account number of the user. It prompts the user to enter their account number and ensures that 
        /// the input is not empty. If the input is invalid, it catches the exception and prompts the user to enter a valid input again.
        /// </summary>
        public void GetUserAccountNumber()
        {
            try
            {
                Console.WriteLine("Please Enter AccountNumber:\n");
                AccountNumber = Console.ReadLine();
                Extension.Instance.EnsureStringNotEmpty(AccountNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}, Please enter valid input.");
                GetUserAccountNumber();
            }
        }
        #endregion

        #region UserName
        /// <summary>
        /// Gets the name of the user. It prompts the user to enter their name as per Aadhaar and ensures that the input 
        /// is not empty. If the input is invalid, it catches the exception and prompts the user to enter a valid input again.
        /// </summary>
        public void GetUserName()
        {
            try
            {
                Console.WriteLine("Please enter Name as per Aadhaar:\n");
                Name = Console.ReadLine();
                Extension.Instance.EnsureStringNotEmpty(Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}, Please enter valid input.");
                GetUserName();
            }
        }
        #endregion

        #region UserGender
        /// <summary>
        /// Gets the sex of the user.
        /// </summary>
        public void GetUserGender()
        {
            try
            {
                Console.WriteLine("Enter Gender:\n");
                Console.WriteLine(string.Join("\n", OptionHelper.GenderType.Values));
                Gender = Console.ReadLine();
                Extension.Instance.EnsureStringNotEmpty(Gender);
                OptionHelper.GenderType.TryGetValue(Gender, out string gender);
                Gender = gender;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}, Please enter valid input.");
                GetUserGender();
            }
        }
        #endregion

        #region GetUserAccountType
        /// <summary>
        /// This method is used to get the account type from the user. It takes an Int16 parameter accType and prompts the user to 
        ///enter the account type. The user can choose between Current Account and Saving Account by entering 1 or 2 respectively. 
        ///The method then assigns the entered value to the accType parameter.
        /// </summary>
        /// <param name="accType"></param>
        public void GetUserAccountType()
        {
            try
            {
                Console.WriteLine("Please Enter AccountType: ");
                Console.WriteLine(string.Join("\n",OptionHelper.AccTypes.Keys.Select(key => $"{key}. {OptionHelper.AccTypes[key]}")));
                string selectedAccountType = Console.ReadLine();
                AccountType = OptionHelper.AccTypes.TryGetValue(selectedAccountType, out string accountType) ? accountType : "Current Account";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}, Please enter valid input.");
                GetUserAccountType();
            }
            Console.WriteLine($"You have selected {AccountType}");
        }
        #endregion

        #region Generate CustomerID

        /// <summary>
        /// This method generates a random customer ID between 10000 and 99999.
        /// </summary>
        /// <returns></returns>
        public int GenerateCustomerId()
        {
            Random rng = new Random();
            return rng.Next(10000, 99999); // Generate a random 5-digit number
        }
        #endregion
        /// <summary>
        /// This method displays the user operation options and takes the user's choice as input.
        /// </summary>
        public static void UserOperationOptions()
        {
            Console.WriteLine("\n");
            Console.WriteLine("--------Menu--------");
            Console.WriteLine(string.Join("\n", OptionHelper.UserOperationOptions.Keys.Select(key => $"{key}. {OptionHelper.UserOperationOptions[key]}")));
            Console.Write("\nPlease select an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (!(choice <= OptionHelper.UserOperationOptions.Count))
                throw new Exception("Invalid choice. Please select a valid option.");

            menuActions.TryGetValue(choice, out Action action);
            action();

            UserOperationOptions(); // Call UserOperationOptions method again to display the options after performing the action
        }
        /// <summary>
        /// This dictionary maps user operation options to their corresponding actions. 
        /// Each key represents a user operation option, and the value is an 
        /// Action delegate that defines the action to be performed when that option is selected.
        /// </summary>
        static Dictionary<int, Action> menuActions = new()
        {
            { 1, () => new CreateNewAccountHelper().CreateNewAccount() },
            { 2, () => Console.WriteLine("Deposit Money") },
            { 3, () => Console.WriteLine("Withdraw Money") },
            { 4, () => Console.WriteLine("Check Balance") },
            { 5, () => DatabaseHelper.GetUserByCustomerID() },
            { 6, () => DatabaseHelper.DisplayAllUsers() },
            { 7, () => Environment.Exit(0) }
        };
    }
}
