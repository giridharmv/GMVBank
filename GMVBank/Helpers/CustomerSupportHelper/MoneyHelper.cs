using GMVBank.DB;

namespace GMVBank.Helpers.ActionHelper
{
    public class MoneyHelper: Database
    {
        public MoneyHelper() { }

        /// <summary>
        /// Method adds the money to the user account based on there unique customerID
        /// </summary>

        public void UserDepositMoney()
        {
            Console.WriteLine("Please Enter the CustomerID of your Account or the account that money should be deposited: ");
            int customerid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the amount to be deposited (in rupees): ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Extension.Instance.EnsureStringNotEmpty($"{customerid};{amount}");
            DepositMoney(amount, customerid);
        }

        /// <summary>
        /// Method subtracts the money from the user account based on their unique customerID
        /// </summary>
        public void UserWithdrawMoney()
        {
            Console.WriteLine("Please Enter the CustomerID of your Account or the account that money should be withdrawn: ");
            int customerid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the amount to be withdrawn (in rupees): ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Extension.Instance.EnsureStringNotEmpty($"{customerid};{amount}");
            WithdrawMoney(amount, customerid);
        }

        /// <summary>
        /// Deposits money into a user's account based on their CustomerID.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static decimal DepositMoney(decimal amount, int CustomerID)
        {

            using (Database db = new())
            {
                // Ensure database is created
                db.Database.EnsureCreated();
                // Find the user by CustomerID
                var user = db.Users.Find(CustomerID);
                if (user == null)
                {
                    throw new Exception($"User with CustomerID {CustomerID} not found.");
                }
                // Update the user's balance
                user.Balance += amount;
                // Save changes to database
                db.SaveChanges();
            }
            return amount; 
        }
        /// <summary>
        /// Withdraw's money from a user's account based on their CustomerID.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static decimal WithdrawMoney(decimal amount, int CustomerID)
        {

            using (Database db = new())
            {
                // Ensure database is created
                db.Database.EnsureCreated();
                // Find the user by CustomerID
                var user = db.Users.Find(CustomerID);
                if (user == null)
                    throw new Exception($"User with CustomerID {CustomerID} not found.");

                if (!(user.Balance>0 && amount <= user.Balance))
                {
                    throw new Exception($"Insufficient balance for User with CustomerID {CustomerID}.");
                }

                // Update the user's balance
                user.Balance -= amount;
                // Save changes to database
                db.SaveChanges();
            }
            return amount; 
        }
    }
}
