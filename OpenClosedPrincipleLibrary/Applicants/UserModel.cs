using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrincipleLibrary
{
    public class UserModel : IUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccounts Account { get; set; } = new Accounts();
    }
}
