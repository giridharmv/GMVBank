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

    }
}
