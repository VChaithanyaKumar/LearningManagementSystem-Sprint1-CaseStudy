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
                LearnerServices learnerServices = null;
                User user = null;
                Course course = null;
                do
                {
                    Console.WriteLine("1. Existing User");
                    Console.WriteLine("2. New User");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {

                                Console.WriteLine("1. Admin Login");
                                Console.WriteLine("2. Learner Login");
                                Console.WriteLine("3. Go Back");
                                Console.Write("Enter your choice: ");
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
                                                    Console.WriteLine("1.Add New Learner");
                                                    Console.WriteLine("2.Delete Learner");
                                                    Console.WriteLine("3.Update User");
                                                    Console.WriteLine("4.Add New Course");
                                                    Console.WriteLine("5.Delete Course");
                                                    Console.WriteLine("6.Update course Details");
                                                    Console.WriteLine("7.Assign Course");
                                                    Console.WriteLine("8.Get Report");
                                                    Console.Write("Choose the Admin Service: ");
                                                    int adminServiceOption = int.Parse(Console.ReadLine());
                                                    switch (adminServiceOption)
                                                    {
                                                        case 6:
                                                            //display all course details
                                                            adminServices = new AdminServices();
                                                            adminServices.GetCourseTitles();
                                                            course = new Course();
                                                            Console.WriteLine("Enter course Id to update");
                                                            course.CourseId = Decimal.Parse(Console.ReadLine());
                                                            Console.WriteLine("1.Update course description");
                                                            Console.WriteLine("2.Update course out comes");
                                                            int ch_update = int.Parse(Console.ReadLine());
                                                            switch (ch_update)
                                                            {
                                                                case 1:
                                                                    Console.WriteLine("Enter the description for");
                                                                    course.CourseDescription = Console.ReadLine();
                                                                    adminServices.UpdateCourseDescription(course);
                                                                    break;
                                                                case 2:
                                                                    Console.WriteLine("Enter the out comes for");
                                                                    course.CourseOutcomes = Console.ReadLine();
                                                                    adminServices.UpdateCourseOutCome(course);
                                                                    break;
                                                            }
                                                            break;
                                                        case 7:
                                                            {
                                                                adminServices = new AdminServices();
                                                                Console.Write("Enter User email to assign a course: ");
                                                                string UserEmail = Console.ReadLine();
                                                                Console.Write("Enter Course Title to assign: ");
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
                                            Console.Write("Enter Email [abc@gmail.com]: ");
                                            user.UserEmail = Console.ReadLine();
                                            Console.Write("Enter Password: ");
                                            user.UserPassword = Console.ReadLine();
                                            //string UserEmail = user.UserEmail;
                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                                                    Console.WriteLine("Learner Services");
                                                    Console.WriteLine("-------------------------");
                                                    
                                                    Console.WriteLine("Enter [1] to Enroll a Course");
                                                    Console.WriteLine("Enter [2] to Complete a Course");
                                                    Console.Write("Enter Learner Service to do: ");
                                                    int loginServiceOption = int.Parse(Console.ReadLine());
                                                    switch (loginServiceOption)
                                                    {
                                                        case 1:
                                                            {
                                                                learnerServices = new LearnerServices();
                                                                learnerServices.GetCourseTitles();
                                                                Console.Write("Enter Course Title to Enroll: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.EnrollCourse(user.UserEmail, CourseTitle);

                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                learnerServices = new LearnerServices();
                                                                Console.Write("Enter Course Title to Enroll: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.CompleteCourse(user.UserEmail, CourseTitle);
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
