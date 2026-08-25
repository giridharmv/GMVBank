using GMVBank.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMVBank.Helpers
{
    public class MoneyHelper: Database
    {
        public MoneyHelper() { }

        /// <summary>
        /// Deposits money into a user's account based on their CustomerID.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static decimal DepositMoney(decimal amount, string CustomerID)
        {

            using (Database db = new())
            {
                // Ensure database is created
                db.Database.EnsureCreated();
                // Find the user by CustomerID
                var user = db.Users.Find(CustomerID);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with CustomerID {CustomerID} not found.");
                }
                // Update the user's balance
                user.Balance += amount;
                // Save changes to database
                db.SaveChanges();
            }

            return amount; // Return the deposited amount
        }
    }
}
