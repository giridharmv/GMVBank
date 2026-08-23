using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMVBank.Helpers
{
    public class OptionHelper
    {
        public readonly static IDictionary<int, string> AccTypes = new Dictionary<int, string>()
        {
            {1,"Current Account" },
            {2,"Saving Account" }
        };
        public readonly static IDictionary<string, string> GenderType = new Dictionary<string, string>()
        {
            {"1","Male" },
            {"2","Female" },
            {"3","Trans" },
            {"4","Other" },
        };
        public readonly static IDictionary<int, string> UserOperationOptions = new Dictionary<int, string>()
        {
            {1,"Open New Account" },
            {2,"Deposit Money" },
            {3,"Withdraw Money" },
            {4,"Check Balance" },
            {5,"Get User details from CustomerID" },
            {6, "Get All User CustomerID's" },
            {7,"Exit" }
        };
    }
}
