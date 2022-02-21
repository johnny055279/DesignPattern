
using LiskovSubstitutionPrincipleLibrary;

IManager manager = new Manager();

manager.FirstName = "Johnny";

manager.LastName = "Wang";

manager.CaculateSalary(4);

BaseEmployee employee = new CEO();

employee.FirstName = "David";

employee.LastName = "Lin";

employee.CaculateSalary(2);

Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}\nSalary: {employee.Salary}");

Console.WriteLine("Press any key to exit");

Console.ReadLine();