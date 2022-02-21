using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipleLibrary
{
    public class Accounts : IAccounts
    {
        public virtual EmployeeModel Create(IUserModel userModel)
        {
            EmployeeModel result = new();

            result.FirstName = userModel.FirstName;

            result.LastName = userModel.LastName;

            result.Email = $"{userModel.FirstName}{userModel.LastName}@gmail.com";

            return result;
        }
    }
}
