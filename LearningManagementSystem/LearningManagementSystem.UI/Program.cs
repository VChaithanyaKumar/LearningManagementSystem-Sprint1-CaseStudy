using System;
using LMS.BAL;
using LMS.BAL.Validations;
using LearningManagementSystem.Entities;
using System.IO;
namespace LearningManagementSystem.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterService registerService = null;
                LoginService loginService = null;
                AdminServices adminServices = null;
                User user = null;
                do
                {
                    Console.WriteLine("1. Existing User");
                    Console.WriteLine("2. New User");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("Enter your choice");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {

                                Console.WriteLine("1. Admin Login");
                                Console.WriteLine("2. Learner Login");
                                Console.WriteLine("3. Go Back");
                                Console.WriteLine("Enter your choice");
                                int ch1 = int.Parse(Console.ReadLine());
                                loginService = new LoginService();
                                switch (ch1)
                                {
                                    case 1:
                                        {
                                            user = new User();
                                            user.UserType = "Admin";
                                            Console.WriteLine("Enter Login Details of an Admin:");
                                            Console.WriteLine("-------------------------------------");
                                            Console.Write("Enter Email [abc@gmail.com]: ");
                                            user.UserEmail = Console.ReadLine();
                                            Console.Write("Enter Password: ");
                                            user.UserPassword = Console.ReadLine();

                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Admin Services");
                                                    Console.WriteLine("-------------------------");
                                                    Console.WriteLine("Enter Admin Service to do");
                                                    Console.WriteLine("Enter [7] to Assign a Course");
                                                    int adminServiceOption = int.Parse(Console.ReadLine());
                                                    switch (adminServiceOption)
                                                    {
                                                        case 7:
                                                            {
                                                                adminServices = new AdminServices();
                                                                Console.Write("Enter User email to assign a course: ");
                                                                string UserEmail = Console.ReadLine();
                                                                Console.WriteLine("Enter Course Title to assign: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                adminServices.AssignCourse(UserEmail, CourseTitle);

                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid choice");
                                                                break;
                                                            }
                                                    }  
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            user = new User();
                                            user.UserType = "Learner";
                                            Console.WriteLine("Enter Login Details of a Learner:");
                                            Console.WriteLine("-------------------------------------");
                                            Console.WriteLine("Enter Email [abc@gmail.com]: ");
                                            user.UserEmail = Console.ReadLine();
                                            Console.WriteLine("Enter Password");
                                            user.UserPassword = Console.ReadLine();
                                            string UserEmail = user.UserEmail;
                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Learner Services");
                                                    Console.WriteLine("-------------------------");
                                                    Console.WriteLine("Enter Learner Service to do");
                                                    Console.WriteLine("Enter [1] to Enroll a Course");
                                                    int adminServiceOption = int.Parse(Console.ReadLine());
                                                    switch (adminServiceOption)
                                                    {
                                                        case 1:
                                                            {
                                                                adminServices = new AdminServices();
                                                                Console.WriteLine("Enter Course Title to Enroll: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                adminServices.AssignCourse(UserEmail, CourseTitle);

                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid choice");
                                                                break;
                                                            }
                                                    } 
                                                }

                                            }
                                            break; 
                                        }
                                    case 3:
                                        {
                                            continue;
                                        }
                                }

                                break;
                            }
                        case 2:
                            {

                                user = new User();
                                registerService = new RegisterService();
                                string passwordRetype = "";
                                user.UserType = "Learner";
                                Console.WriteLine("Enter Learner Details:");
                                Console.Write("Enter First name: ");
                                user.UserFirstName = Console.ReadLine();
                                Console.Write("Enter Last name: ");
                                user.UserLastName = Console.ReadLine();
                                Console.Write("Enter Gender ['M'/'F']: ");
                                user.Gender = char.Parse(Console.ReadLine());
                                Console.Write("Enter Email [abc@gmail.com]: ");
                                user.UserEmail = Console.ReadLine();
                            PaswordType:
                                
                                    Console.Write("Enter password [Length- (8-15), one Upper Case, one Lower Case]: ");
                                    user.UserPassword = Console.ReadLine();
                                if (!RegisterValidation.ValidatePassword(user.UserPassword))
                                {
                                    Console.WriteLine("Your Password is meeting the requirements!! Please try again: ");
                                    goto PaswordType;
                                }
                               
                                    Console.Write("Retype Password: ");
                                    passwordRetype = Console.ReadLine(); 
                                    if(!RegisterValidation.CheckPassword(user.UserPassword, passwordRetype))
                                    {
                                        Console.WriteLine("Password and Confirm Password are not matching!!");
                                        goto PaswordType;
                                    }
                                
                                Console.WriteLine(registerService.RegisterUser(user));
                                break;
                            }
                        case 3:
                            {

                                return;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice");
                                break;
                            }
                    }
                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
