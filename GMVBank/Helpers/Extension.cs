using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMVBank.Helpers
{
    public class Extension
    {
        #region Singelton Pattern
        private static readonly Extension _instance = new Extension();
        public static Extension Instance => _instance;
        private Extension() { }
        #endregion

        /// <summary>
        /// Ensures that the input integer is in the range of user definer number.
        /// </summary>
        public int EnsureIntegerInRange(int value, int lowerLimit, int higherLimit)
        {
            if (!(value <= higherLimit && value > lowerLimit)) 
                throw new Exception($"Input value {value} is out of range. Please enter a value between {lowerLimit} and {higherLimit}.");
            
            return value;
        }
        /// <summary>
        /// Ensures that the input string is not null or empty. If it is, an exception is thrown.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="Exception"></exception>
        public void EnsureStringNotEmpty(string input)
        {

            foreach (var str in input.Split(';'))
            {
                if (string.IsNullOrWhiteSpace(str))
                    throw new Exception($"Input {input} is null. Please enter a valid value.");
            }
        }
    }
}
