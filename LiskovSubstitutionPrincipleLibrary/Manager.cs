using System;
namespace LiskovSubstitutionPrincipleLibrary
{
	public class Manager : Employee, IManager
	{
        public override void CaculateSalary(int rank)
        {
            decimal baseSalary = 200;

            Salary = baseSalary + (rank * 2);
        }

        public void GeneratePerformanceReview()
        {
            Console.WriteLine("Performance report Generated.");
        }
    }
}

