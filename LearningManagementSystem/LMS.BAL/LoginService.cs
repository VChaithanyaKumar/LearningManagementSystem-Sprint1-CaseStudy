using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.DAL;
using LMS.BAL.Validations;
using LearningManagementSystem.Entities;
namespace LMS.BAL
{
    public class LoginService
    {
        private LoginRepository login = new LoginRepository();
        User userObj = new User();
        public bool LoginUser(User user)
        {
            userObj=login.GetLoginDetails(user.UserEmail);
            if (userObj == null)
            {
                Console.WriteLine("Invalid Email! Please Try again");
                return false;
            }
            if (!LoginValidation.CheckUserType(user.UserType,userObj.UserType))
            {
                Console.WriteLine("User is not " + user.UserType);
                return false;
            }
            if (LoginValidation.CheckPassword(user.UserPassword, userObj.UserPassword))
            {
                Console.WriteLine("Logged In!!");
                return LoginValidation.LoginFlag();
                
            }
            else
            {
                Console.WriteLine("Invalid Password!! Please Try again");
                return false;
            }

        }
    }
}
