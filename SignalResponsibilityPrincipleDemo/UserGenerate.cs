using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalResponsibilityPrincipleDemo
{
    public class UserGenerate
    {
        public static void CreateAccount(User user)
        {
            Console.WriteLine($"Your name is {user.FirstName} {user.LastName}");
        }
    }
}
