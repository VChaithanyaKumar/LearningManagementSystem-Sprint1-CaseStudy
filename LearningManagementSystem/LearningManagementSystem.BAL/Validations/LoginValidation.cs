using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BAL.Validations
{
    public class LoginValidation
    {
        public static bool CheckPassword(string DbPassword, string UserPassword)
        {
            if (DbPassword.Equals(UserPassword))
            {
                return true;
            }
            else
                return false;
        }
        public static bool CheckUserType(string DbUserType, string UserType)
        {
            if (DbUserType.Equals(UserType))
            {
                return true;
            }
            else
                return false;
        }
    }
}
