using System;
namespace LiskovSubstitutionPrincipleLibrary
{
	public interface IManager : IEmployee
	{
		void GeneratePerformanceReview();
	}
}

