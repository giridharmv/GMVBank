using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMVBank.Interface
{
    internal interface IUserData
    {
        string Name { get; set; }
        string AccountNumber { get; set; }
        int AccountType { get; set; }
        string Gender { get; set; }
    }
}
