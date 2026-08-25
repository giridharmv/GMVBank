using GMVBank.DB;
using GMVBank.Helpers.ActionHelper;
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

            GetUserDetails.UserOperationOptions(); // Call the method to display user operation options
        }
        #endregion
    }
}
