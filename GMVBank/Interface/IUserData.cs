namespace GMVBank.Interface
{
    internal interface IUserData
    {
        int CustomerID { get; set; }
        string Name { get; set; }
        string AccountNumber { get; set; }
        string AccountType { get; set; }
        string Gender { get; set; }
    }
}
