namespace OpenClosedPrincipleLibrary
{
    public interface IUserModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        IAccounts Account { get; set; }
    }
}