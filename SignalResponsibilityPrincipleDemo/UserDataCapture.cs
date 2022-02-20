using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalResponsibilityPrincipleDemo
{
    public class UserDataCapture
    {
        // 取得使用者
        public static User GetUser()
        {
            User user = new();

            Console.Write("What is your first name?");

            user.FirstName = Console.ReadLine();

            Console.Write("What is your last name?");

            user.LastName = Console.ReadLine();

            return user;
        }
    }
}
