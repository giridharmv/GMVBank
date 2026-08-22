using GMVBank.Interface;

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

        int _userAccType;
        string _userGender = "male";
        string _name = "Giri";
        string _accountNumber = "912837483";
        public int AccountType
        {
            get => _userAccType;
            set => _userAccType = value;
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
                AccountType = Convert.ToInt32(Console.ReadLine());
                AccountType = Extension.Instance.EnsureIntegerInRange(AccountType, 0, OptionHelper.AccTypes.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}, Please enter valid input.");
                GetUserAccountType();
            }
            Console.WriteLine($"You have selected {OptionHelper.AccTypes[AccountType]}");
        }

        #endregion
    }
}
