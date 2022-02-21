namespace LiskovSubstitutionPrincipleLibrary;

public class Employee : BaseEmployee, IManaged
{
    public IEmployee Manager { get; set; }

    public void AssignManager(IEmployee manager)
    {
        Manager = manager;
    }
}

