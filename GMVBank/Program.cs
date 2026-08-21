using GMVBank.Helpers;
using GMVBank.Interface;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Xml;
using System.Xml.Linq;

namespace GMVBank
{
    public class Program
    {
       

        #region Main Method
        static void Main()
        {
            Console.WriteLine("************* WELCOME TO GMVBANK *************");

            Program p = new Program(); // Create an instance of the Program class

            p.UserDetails(); // Call the GetUserDetails method to get user details
        }
        #endregion
        /// <summary>
        /// calls the GetUserDetails class to get the user details like name, account number, account
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
