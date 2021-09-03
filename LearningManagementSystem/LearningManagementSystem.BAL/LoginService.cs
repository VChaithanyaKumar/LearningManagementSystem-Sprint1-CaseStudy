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
        public string LoginUser(User user)
        {
            userObj=login.GetLoginDetails(user.UserEmail);
            if (userObj == null)
            {
                return "Invalid Email";
            }
            if (!LoginValidation.CheckUserType(user.UserType,userObj.UserType))
            {
                return "User is not " + user.UserType;
            }
            if (LoginValidation.CheckPassword(user.UserPassword, userObj.UserPassword))
            {
                return "Logged In!!";
            }
            else
            {
                return "Invalid Password!! ";
            }

        }
    }
}
