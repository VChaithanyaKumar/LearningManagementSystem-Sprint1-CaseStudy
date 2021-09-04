using System;
using LMS.BAL;
using LMS.BAL.Validations;
using LearningManagementSystem.Entities;//accessing Business Objects
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
                Question question = null;
                do
                {
                    //Menu Options
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
                                Console.WriteLine("3. Go Back to Main Menu");
                                Console.Write("Enter your choice: ");
                                int ch1 = int.Parse(Console.ReadLine());
                                loginService = new LoginService();
                                switch (ch1)
                                {
                                    case 1:
                                        {
                                            //Admin Login--Praveena
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
                                                    //Admin Services Provided
                                                    Console.WriteLine("Admin Services");
                                                    Console.WriteLine("-------------------------");
                                                    Console.WriteLine("1.Add New User");
                                                    Console.WriteLine("2.Update User");
                                                    Console.WriteLine("3.Delete User");
                                                    Console.WriteLine("4.Add New Course");
                                                    Console.WriteLine("5.Delete Course");
                                                    Console.WriteLine("6.Update course Details");
                                                    Console.WriteLine("7.Assign Course");
                                                    Console.WriteLine("8.Get Course Status: ");
                                                    Console.WriteLine("9.Get Report");
                                                    Console.WriteLine("10.Go Back to Login Menu");
                                                    Console.Write("Choose the Admin Service: ");
                                                    int adminServiceOption = int.Parse(Console.ReadLine());
                                                    switch (adminServiceOption)
                                                    {
                                                        //Add User
                                                        case 1:
                                                            user = new User();
                                                            registerService = new RegisterService();
                                                            string passwordRetype = "";
                                                            Console.Write("Enter User Type[ Admin/ Leaner]: ");
                                                            user.UserType = Console.ReadLine();
                                                            Console.Write("Enter Learner Details:");
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
                                                            if (!RegisterValidation.CheckPassword(user.UserPassword, passwordRetype))
                                                            {
                                                                Console.WriteLine("Password and Confirm Password are not matching!!");
                                                                goto PaswordType;
                                                            }

                                                            Console.WriteLine(registerService.RegisterUser(user));
                                                            break;
                                                        case 2:
                                                            //Update Password
                                                            adminServices = new AdminServices();
                                                            Console.Write("Enter the User Email to Update Password: ");
                                                            string Email = Console.ReadLine();
                                                            Console.Write("Enter Old PassWord: ");
                                                            string OldPassword = Console.ReadLine();
                                                            Console.Write("Enter New PassWord: ");
                                                            string NewPassword = Console.ReadLine();
                                                            adminServices.UpdatePassword(Email, OldPassword, NewPassword);
                                                            break;
                                                        case 3:
                                                            //delete User
                                                            adminServices = new AdminServices();
                                                            Console.WriteLine("Enter User Email to delete the User");
                                                            adminServices.DeleteUser(Console.ReadLine());
                                                            break;
                                                        case 4:
                                                            //Add New Course
                                                            Console.WriteLine("----------Adding New Course--------------");
                                                            course = new Course();
                                                            Console.Write("Enter Course Title: ");
                                                            course.CourseTitle = Console.ReadLine();
                                                            Console.Write("Enter Course Description: ");
                                                            course.CourseDescription = Console.ReadLine();
                                                            Console.Write("Enter Course OutComes: ");
                                                            course.CourseOutcomes = Console.ReadLine();
                                                            adminServices.AddCourse(course);
                                                            Console.Write("Do you want to add question and answer to the Course:Enter['Y'/'N']: ");
                                                            char choice = Char.Parse(Console.ReadLine());
                                                            if (choice == 'Y')
                                                            {
                                                                Console.Write("Enter the number of questions: ");
                                                                int question_nums = int.Parse(Console.ReadLine());
                                                                for (var i = 1; i <= question_nums; i++)
                                                                {
                                                                    question = new Question();
                                                                    Console.Write("Enter question number: " + i);
                                                                    question.QuestionDescription = Console.ReadLine();
                                                                    Console.Write("Enter Answer for question: " + i);
                                                                    question.AnswerDescription = Console.ReadLine();
                                                                    adminServices.AddCourseQuestion(question, course);

                                                                }
                                                            }
                                                            break;
                                                        case 5:
                                                            //delete Course:
                                                            adminServices = new AdminServices();
                                                            adminServices.GetCourseTitles();
                                                            Console.Write("Enter Course title to delete:");
                                                            adminServices.DeleteCourse(Console.ReadLine());
                                                            break;
                                                        case 6:
                                                            //update course details
                                                            adminServices = new AdminServices();
                                                            //displaying course titles
                                                            adminServices.GetCourseTitles();
                                                            course = new Course();
                                                            Console.WriteLine("Enter course title to update");
                                                            course.CourseTitle = (Console.ReadLine());
                                                            Console.WriteLine("1.Update course description");
                                                            Console.WriteLine("2.Update course out comes");
                                                            Console.Write("Enter your choice: ");
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
                                                                //Assign User to the Course..
                                                                adminServices = new AdminServices();
                                                                Console.Write("Enter User email to assign a course: ");
                                                                string UserEmail = Console.ReadLine();
                                                                Console.Write("Enter Course Title to assign: ");
                                                                adminServices.AssignCourse(UserEmail, Console.ReadLine());

                                                                break;
                                                            }
                                                        case 8:
                                                            {
                                                                //Get Completed Status.
                                                                adminServices = new AdminServices();
                                                                Console.Write("Enter the UserId to get complete status: ");
                                                                int UserId = int.Parse(Console.ReadLine());
                                                                Console.WriteLine("Course Status of a Learner:");
                                                                Console.WriteLine("_________________________________");
                                                                Console.WriteLine("UserName |Course         |Staus  ");
                                                                Console.WriteLine("_________________________________");
                                                                adminServices.CourseStatus(UserId);
                                                                Console.WriteLine("_________________________________");
                                                                break;
                                                            }
                                                        case 9:
                                                            {
                                                                //report on the available data – course wise, status of completion wise.
                                                                adminServices = new AdminServices();
                                                                Console.WriteLine("Generate the Report Of a User:");
                                                                Console.Write("Enter the UserEmail to get Report: ");
                                                                string UserEmail = (Console.ReadLine());
                                                                Console.WriteLine("_________________________________");
                                                                adminServices.GenearteReport(UserEmail);
                                                                Console.WriteLine("_________________________________");
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid choice");
                                                                break;
                                                            }
                                                        case 10:

                                                            return;
                                                        
                                                    }  
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            //Learner Login--Praveena
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
                                                    Console.WriteLine("Enter [3] to go back to Login Menu");
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
                                                                Console.Write("Enter Course Title to Complete: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.CompleteCourse(user.UserEmail, CourseTitle);
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                Console.WriteLine("Invalid choice");
                                                                break;
                                                            }
                                                        case 3:
                                                            continue;
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
                                //New User Register Functionality
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
