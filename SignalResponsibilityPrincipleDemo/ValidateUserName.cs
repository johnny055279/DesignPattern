using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalResponsibilityPrincipleDemo
{
    public class ValidateUserName
    {
        // 驗證輸入資訊
        public static bool Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                ShowMessage.ShowErrorMessage("first name");

                return false;
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                ShowMessage.ShowErrorMessage("last name");

                return false;
            }

            return true;
        }
    }
}
