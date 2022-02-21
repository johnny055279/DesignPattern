namespace LiskovSubstitutionPrincipleLibrary
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }
        void CaculateSalary(int rank);
    }
}