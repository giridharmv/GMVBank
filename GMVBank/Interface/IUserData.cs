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
