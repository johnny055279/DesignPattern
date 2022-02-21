using System;
namespace LiskovSubstitutionPrincipleLibrary
{
	public class CEO : BaseEmployee, IManager
	{
        public override void CaculateSalary(int rank)
        {
            decimal baseSalary = 400;

            Salary = baseSalary + rank;
        }

        public void GeneratePerformanceReview()
        {
            Console.WriteLine("Performance report Generated.");
        }

        public void FireSomeone(Employee employee)
        {
            Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} have been fired by CEO!");
        }
    }
}

