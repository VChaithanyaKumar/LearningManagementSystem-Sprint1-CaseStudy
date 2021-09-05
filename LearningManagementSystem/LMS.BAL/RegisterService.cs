using System;
using LMS.DAL;
using LMS.BAL.Validations;
using LearningManagementSystem.Entities;
namespace LMS.BAL
{
    //Registration-- Josy George
    public class RegisterService
    {
        //object reference for RegisterRepository
        private RegisterRepository register = new RegisterRepository();

        //invoking AddUser from the RegisterRepository
        
        public string RegisterUser(User user)
        {
                register.AddingUser(user);
                return "SucessfullyAdded!";
        }

    }
}
