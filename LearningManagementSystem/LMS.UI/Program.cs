using System;
using LMS.BAL;
using LMS.BAL.Validations;
using LearningManagementSystem.Entities;//accessing Business Objects
using System.IO;
using System.Collections.Generic;

namespace LMS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterService registerService = null;//object declaration for register services
                LoginService loginService = null;//object declaration for login services
                AdminServices adminServices = null;//object declaration for Admin services
                LearnerServices learnerServices = null;//object declaration for Learner services
                User user = null;//object declaration for User
                Course course = null;//object declaration for Course
                Question question = null;//object declaration for Question
                do
                {
                    //Menu Options
         MainMenu:  Console.WriteLine("1. Existing User");
                    Console.WriteLine("2. New User");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {

                LoginMenu:      Console.WriteLine("1. Admin Login");
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
                                            //password masking
                                            ConsoleKey key;
                                            do
                                            {
                                                var keyInfo = Console.ReadKey(intercept: true);
                                                key = keyInfo.Key;

                                                if (key == ConsoleKey.Backspace && user.UserPassword.Length > 0)
                                                {
                                                    Console.Write("\b \b");
                                                    user.UserPassword = user.UserPassword[0..^1];
                                                }
                                                else if (!char.IsControl(keyInfo.KeyChar))
                                                {
                                                    Console.Write("*");
                                                    user.UserPassword += keyInfo.KeyChar;
                                                }
                                            } while (key != ConsoleKey.Enter);
                                            //user.UserPassword = Console.ReadLine();

                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                                                    //Admin Services Provided
                    AdminServices:                  Console.WriteLine("Admin Services");
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
                                                            //user.UserPassword = Console.ReadLine();
                                                            //Password Masking
                                                            do
                                                            {
                                                                var keyInfo = Console.ReadKey(intercept: true);
                                                                key = keyInfo.Key;

                                                                if (key == ConsoleKey.Backspace && user.UserPassword.Length > 0)
                                                                {
                                                                    Console.Write("\b \b");
                                                                    user.UserPassword = user.UserPassword[0..^1];
                                                                }
                                                                else if (!char.IsControl(keyInfo.KeyChar))
                                                                {
                                                                    Console.Write("*");
                                                                    user.UserPassword += keyInfo.KeyChar;
                                                                }
                                                            } while (key != ConsoleKey.Enter);
                                                            if (!RegisterValidation.ValidatePassword(user.UserPassword))
                                                            {
                                                                Console.WriteLine();
                                                                Console.WriteLine("Your Password is not meeting the requirements!! Please try again: ");
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
                                                            char choice = char.Parse(Console.ReadLine());
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
                                                            adminServices.GetCourseTitles();//Gets all the Courses
                                                            course = new Course();
                                                            Console.WriteLine("Enter course title to update");
                                                            course.CourseTitle = Console.ReadLine();
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
                                                                string UserEmail = Console.ReadLine();
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

                                                            goto LoginMenu;

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
                    LearnerLogin:                        Console.Write("Enter Email [abc@gmail.com]: ");
                                            user.UserEmail = Console.ReadLine();
                                            Console.Write("Enter Password: ");
                                            //password masking!
                                            ConsoleKey key;
                                            do
                                            {
                                                var keyInfo = Console.ReadKey(intercept: true);
                                                key = keyInfo.Key;

                                                if (key == ConsoleKey.Backspace && user.UserPassword.Length > 0)
                                                {
                                                    Console.Write("\b \b");
                                                    user.UserPassword = user.UserPassword[0..^1];
                                                }
                                                else if (!char.IsControl(keyInfo.KeyChar))
                                                {
                                                    Console.Write("*");
                                                    user.UserPassword += keyInfo.KeyChar;
                                                }
                                            } while (key != ConsoleKey.Enter);
                                            //user.UserPassword = Console.ReadLine();
                                            //string UserEmail = user.UserEmail;
                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                    LoginServices:                  Console.WriteLine("Learner Services");
                                                    Console.WriteLine("-------------------------");

                                                    Console.WriteLine("Enter [1] to Enroll a Course");
                                                    Console.WriteLine("Enter [2] to Complete a Course");
                                                    Console.WriteLine("Enter [3] to Attemp Test");
                                                    Console.WriteLine("Enter [4] to View Course Completion Certificate");
                                                    Console.WriteLine("Enter [5] to go back to Login Menu");
                                                    Console.Write("Enter Learner Service to do: ");
                                                    int loginServiceOption = int.Parse(Console.ReadLine());
                                                    switch (loginServiceOption)//Validation For Learner Login
                                                    {
                                                        case 1:
                                                            {
                                                                //Course Enroll--Praveena
                                                                course = new Course();
                                                                learnerServices = new LearnerServices();
                                                                learnerServices.GetCourseTitles();
                                                                Console.Write("Enter Course Title to Enroll: ");
                                                                course.CourseTitle = Console.ReadLine();
                                                                learnerServices.EnrollCourse(user, course);

                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                //Complete the Course--Praveena
                                                                learnerServices = new LearnerServices();
                                                                Console.Write("Enter Course Title to Complete: ");
                                                                learnerServices.CompleteCourse(user, Console.ReadLine());
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                //Taking Test--Sai Kiran
                                                                learnerServices = new LearnerServices();
                                                                Console.WriteLine("Want to Take Test?");
                                                                Console.WriteLine("Here is the List Of courses you completed");
                                                                learnerServices.GetCompletedCourses(user.UserEmail);
                                                                Console.Write("Enter Course Name To take Test: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.StartTest(user.UserEmail, CourseTitle);
                                                                //int questionCount = learnerServices.GetQuestionCount(CourseTitle);
                                                                List<string> Questions = learnerServices.GetQuestions(CourseTitle);
                                                                List<string> Answers = new List<string>();
                                                                for (int i = 0; i < Questions.Count; i++)
                                                                {
                                                                    Console.WriteLine((i+1) + "." + Questions[i]);
                                                                    Console.Write("Type Answer: ");
                                                                    Answers.Add(Console.ReadLine());

                                                                }
                                                                learnerServices.SubmitTest(Answers, CourseTitle, user.UserEmail);
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                //Course Completetion Certificate--Praveena
                                                                learnerServices = new LearnerServices();
                                                                Console.WriteLine("Here is the List Of courses you completed");
                                                                learnerServices.GetCompletedCourses(user.UserEmail);
                                                                Console.Write("Enter Course Name To get Certificate: ");
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.ViewSubmissionCertificate(user, CourseTitle);
                                                                break;
                                                            }
                                                        default:
                                                            {

                                                                Console.WriteLine("Invalid choice");
                                                                break;
                                                            }
                                                        case 5:
                                                            break;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                goto LearnerLogin;
                                            }
                                            //break;
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
                                Console.Write("Enter Password: ");
                                ConsoleKey key;
                                do
                                {
                                    var keyInfo = Console.ReadKey(intercept: true);
                                    key = keyInfo.Key;

                                    if (key == ConsoleKey.Backspace && user.UserPassword.Length > 0)
                                    {
                                        Console.Write("\b \b");
                                        user.UserPassword = user.UserPassword[0..^1];
                                    }
                                    else if (!char.IsControl(keyInfo.KeyChar))
                                    {
                                        Console.Write("*");
                                        user.UserPassword += keyInfo.KeyChar;
                                    }
                                } while (key != ConsoleKey.Enter);
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

