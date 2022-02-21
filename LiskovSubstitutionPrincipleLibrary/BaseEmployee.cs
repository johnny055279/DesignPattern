using System;
namespace LiskovSubstitutionPrincipleLibrary
{
	public abstract class BaseEmployee : IEmployee
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public virtual void CaculateSalary(int rank)
        {
            decimal baseSalary = 100;

            Salary = baseSalary + (rank * 2);

        }
    }
}

