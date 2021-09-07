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
                    string s = "Welcome to Learning Management System";
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                    Console.WriteLine(s);
                    Console.WriteLine();
                    Console.WriteLine();
                MainMenu: Console.WriteLine("Please select the options below to proceed");
                    Console.WriteLine();
                    Console.WriteLine("Enter [1] for 'Existing User'");

                    Console.WriteLine("Enter [2] for 'New User'");

                    Console.WriteLine("Enter [3] to 'Exit'");

                    Console.Write("Enter your choice: ");

                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            {

                                Console.WriteLine();
                            LoginMenu: Console.WriteLine("Please select your respected 'login' to proceed to below");
                                Console.WriteLine();
                                Console.WriteLine("Enter [1] 'Admin Login'");

                                Console.WriteLine("Enter [2] 'Learner Login'");

                                Console.WriteLine("Enter [3] to 'Go Back to Main Menu'");

                                Console.Write("Enter your choice: ");
                                /*Console.WriteLine();*/
                                int ch1 = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                loginService = new LoginService();
                                switch (ch1)
                                {
                                    case 1:
                                        {

                                            //Admin Login--Praveena
                                            Console.WriteLine();
                                            user = new User();
                                            user.UserType = "Admin";
                                            Console.WriteLine("Login Details of an Admin:");
                                            Console.WriteLine("-------------------------------------");
                                            Console.WriteLine();
                                        PasswordReEnter: Console.Write("Enter Email [abc@gmail.com]: ");
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
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            //user.UserPassword = Console.ReadLine();

                                            if (loginService.LoginUser(user))
                                            {
                                                while (true)
                                                {
                                                    //Admin Services Provided
                                                    Console.WriteLine();
                                                AdminServices: Console.WriteLine("Admin Services List:");
                                                    Console.WriteLine("-------------------------");
                                                    Console.WriteLine("Enter [1] 'Add New User'");
                                                    Console.WriteLine("Enter [2] 'Update User's Password'");
                                                    Console.WriteLine("Enter [3] 'Delete User'");
                                                    Console.WriteLine("Enter [4] 'Add New Course'");
                                                    Console.WriteLine("Enter [5] 'Delete Course'");
                                                    Console.WriteLine("Enter [6] 'Update Course Details'");
                                                    Console.WriteLine("Enter [7] 'Assign Course'");
                                                    Console.WriteLine("Enter [8] 'Get Course Status' ");
                                                    Console.WriteLine("Enter [9] 'Get Report'");
                                                    Console.WriteLine("Enter [10] 'Go Back to Login Menu'");
                                                    Console.Write("Choose the Admin Service: ");

                                                    int adminServiceOption = int.Parse(Console.ReadLine());
                                                    switch (adminServiceOption)
                                                    {
                                                        //Add User
                                                        case 1:
                                                            user = new User();
                                                            Console.WriteLine();
                                                            Console.WriteLine("----------------Adding New User-----------------");
                                                            registerService = new RegisterService();
                                                            string passwordRetype = "";
                                                            Console.Write("Enter User Type[ Admin/ Leaner]: ");
                                                            user.UserType = Console.ReadLine();


                                                            Console.WriteLine("Enter user Details:");
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
                                                            Console.WriteLine();
                                                            Console.Write("Retype Password: ");
                                                            passwordRetype = Console.ReadLine();
                                                            Console.WriteLine();
                                                            if (!RegisterValidation.CheckPassword(user.UserPassword, passwordRetype))
                                                            {
                                                                Console.WriteLine("Password and Confirm Password are not matching!!");
                                                                goto PaswordType;
                                                            }

                                                            Console.WriteLine(registerService.RegisterUser(user));
                                                            break;
                                                        case 2:
                                                            //Update Password
                                                            Console.WriteLine();

                                                            Console.WriteLine("----------------Update User Password-----------------");
                                                            adminServices = new AdminServices();
                                                            Console.WriteLine("List Of UserEmails");
                                                            Console.WriteLine();
                                                            adminServices.GetAllUserEmails();
                                                            Console.WriteLine();
                                                            Console.Write("Enter the User Email to Update Password: ");
                                                            string Email = Console.ReadLine();
                                                            string s1 = "Enter New Password: ";
                                                        NewPasswordReEnter: Console.WriteLine(s1);
                                                            Console.SetCursorPosition((s1.Length), Console.CursorTop - 1);
                                                            string NewPassword = Console.ReadLine();
                                                            if (!RegisterValidation.ValidatePassword(NewPassword))
                                                            {
                                                                Console.WriteLine();
                                                                Console.WriteLine("Your Password is not meeting the requirements!! Please try again: ");
                                                                goto NewPasswordReEnter;
                                                            }
                                                            adminServices.UpdatePassword(Email, NewPassword);
                                                            Console.WriteLine();
                                                            break;
                                                        case 3:
                                                            //delete User
                                                            Console.WriteLine();

                                                            /*adminServices = new AdminServices();*/
                                                            Console.WriteLine("----------------Deleting User-----------------");
                                                            Console.WriteLine();
                                                            adminServices = new AdminServices();
                                                            Console.WriteLine("List Of UserEmails");
                                                            Console.WriteLine();
                                                            adminServices.GetAllUserEmails();
                                                            Console.WriteLine();
                                                            string s2 = "Enter User Email to delete the User: ";
                                                            Console.WriteLine(s2);
                                                            Console.SetCursorPosition((s2.Length), Console.CursorTop - 1);
                                                            adminServices.DeleteUser(Console.ReadLine());
                                                            Console.WriteLine();
                                                            break;
                                                        case 4:
                                                            //Add New Course
                                                            Console.WriteLine();
                                                            Console.WriteLine();
                                                            adminServices = new AdminServices();

                                                            Console.WriteLine("----------Adding New Course--------------");
                                                            Console.WriteLine();
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
                                                                    Console.Write("Enter question number {0}: " , i);
                                                                    question.QuestionDescription = Console.ReadLine();
                                                                    Console.Write("Enter Answer for question {0}: " , i);
                                                                    question.AnswerDescription = Console.ReadLine();
                                                                    adminServices.AddCourseQuestion(question, course);

                                                                }
                                                            }
                                                            break;
                                                        case 5:

                                                            //delete Course:
                                                            Console.WriteLine();
                                                            Console.WriteLine("----------------Deleting a Course-----------------");
                                                            Console.WriteLine();
                                                            adminServices = new AdminServices();
                                                            Console.WriteLine("List of all the Courses");
                                                            adminServices.GetCourseTitles();
                                                            Console.WriteLine();
                                                            Console.Write("Enter Course title to delete:");
                                                            string CourseTitle = Console.ReadLine();
                                                            adminServices.DeleteCourse(CourseTitle);
                                                            Console.WriteLine(CourseTitle + "Course is deleted");
                                                            break;
                                                        case 6:

                                                            //update course details
                                                            Console.WriteLine();
                                                            Console.WriteLine("----------------Updating a Course-----------------");
                                                            adminServices = new AdminServices();
                                                            //displaying course titles
                                                            Console.WriteLine("List of all the Courses");
                                                            Console.WriteLine();
                                                            adminServices.GetCourseTitles();//Gets all the Courses
                                                            course = new Course();
                                                            Console.Write("Enter Course title to update: ");
                                                            course.CourseTitle = Console.ReadLine();
                                                            Console.WriteLine("1.Update Course Description");
                                                            Console.WriteLine("2.Update Course Outcomes");
                                                            Console.Write("Enter your choice: ");
                                                            int ch_update = int.Parse(Console.ReadLine());
                                                            switch (ch_update)
                                                            {
                                                                case 1:
                                                                    Console.Write("Enter the new description: ");
                                                                    course.CourseDescription = Console.ReadLine();
                                                                    adminServices.UpdateCourseDescription(course);
                                                                    Console.WriteLine("Course Description has been updated successfully");
                                                                    break;
                                                                case 2:
                                                                    Console.Write("Enter the new outcomes: ");
                                                                    course.CourseOutcomes = Console.ReadLine();
                                                                    adminServices.UpdateCourseOutCome(course);
                                                                    Console.WriteLine("Course Outcome has been updated successfully");
                                                                    break;
                                                            }
                                                            break;
                                                        case 7:
                                                            {

                                                                //Assign User to the Course..
                                                                Console.WriteLine();
                                                                Console.WriteLine("----------------Assigning User to Course-----------------");
                                                                adminServices = new AdminServices();
                                                                Console.WriteLine("List of all the Emails");
                                                                Console.WriteLine();
                                                                adminServices.GetAllUserEmails();
                                                                Console.Write("Enter User email to assign a course: ");
                                                                string UserEmail = Console.ReadLine();
                                                                Console.WriteLine("List of all the courses");
                                                                Console.WriteLine();
                                                                adminServices.GetCourseTitles();
                                                                Console.Write("Enter Course Title to assign: ");
                                                                string CourseName = Console.ReadLine();
                                                                adminServices.AssignCoursebyAdmin(UserEmail, CourseName);

                                                                break;
                                                            }
                                                        case 8:
                                                            {
                                                                /*
                                                                                                                                //Get Completed Status.
                                                                                                                                Console.WriteLine();
                                                                                                                                Console.WriteLine("----------------Get User Course Completion Status-----------------");
                                                                                                                                adminServices = new AdminServices();
                                                                                                                                Console.WriteLine("List of Users");
                                                                                                                                Console.WriteLine();
                                                                                                                                adminServices = new AdminServices();
                                                                                                                                adminServices.GetUserIdEmail();
                                                                                                                                Console.Write("Enter the UserId to get complete status: ");
                                                                                                                                int UserId = int.Parse(Console.ReadLine());
                                                                                                                                Console.WriteLine("Course Status of a Learner:");
                                                                                                                                Console.WriteLine("_________________________________");
                                                                                                                                Console.WriteLine("UserName |Course         |Staus  ");
                                                                                                                                Console.WriteLine("_________________________________");
                                                                                                                                adminServices.CourseStatus(UserId);
                                                                                                                                Console.WriteLine("_________________________________");*/
                                                                /*/ Get Completed Status.*/
                                                                Console.WriteLine("----------------Get User Course Completion Status-----------------");
                                                                //Get Completed Status.
                                                                adminServices = new AdminServices();
                                                                Console.WriteLine("Details of All Users:");
                                                                Console.WriteLine("_______________________");
                                                                Console.WriteLine("UserEmail |UserId   ");
                                                                Console.WriteLine("_______________________");
                                                                adminServices.GetUserIdEmail();
                                                                Console.WriteLine("_______________________");

                                                                Console.Write("Enter the UserId to get complete status: ");
                                                                int UserId = int.Parse(Console.ReadLine());
                                                                Console.WriteLine("Course Status of a Learner:");
                                                                Console.WriteLine("___________");
                                                                Console.WriteLine("UserName |Course         |Staus  ");
                                                                Console.WriteLine("___________");
                                                                adminServices.CourseStatus(UserId);
                                                                Console.WriteLine("___________");
                                                                break;
                                                            }
                                                        case 9:
                                                            {

                                                                //report on the available data – course wise, status of completion wise.
                                                                Console.WriteLine();
                                                                adminServices = new AdminServices();
                                                                Console.WriteLine("-----------Generating the Report------------ ");
                                                                /* Console.WriteLine("List of UserEmails");
                                                                 adminServices.GetAllUserEmails();
                                                                 Console.Write("Enter the UserEmail to get Report: ");
                                                                 string UserEmail = Console.ReadLine();*/
                                                                Console.WriteLine("_____________________________________________________________________________________________");
                                                                Console.WriteLine("UserId -  UserEmail  - CourseId  -  CourseTitle  -  StartDate  -  EndDate   -  CompletionStatus");
                                                                adminServices.GenearteReport();
                                                                Console.WriteLine("_____________________________________________________________________________________________");
                                                                Console.WriteLine();
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
                                            else
                                            {
                                                goto PasswordReEnter;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            //Learner Login--Praveena
                                            Console.WriteLine();
                                            user = new User();
                                            user.UserType = "Learner";
                                            Console.WriteLine("Learner Login Page");
                                            Console.WriteLine();
                                            Console.WriteLine("Enter Login Details of a Learner:");
                                            Console.WriteLine("-------------------------------------");
                                            Console.WriteLine();
                                        LearnerLogin: Console.Write("Enter Email [abc@gmail.com]: ");
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
                                                LoginServices: Console.WriteLine("Learner Services");
                                                    Console.WriteLine("-------------------------");
                                                    Console.WriteLine();
                                                    Console.WriteLine("Enter [1] to Enroll a Course");
                                                    Console.WriteLine("Enter [2] to Complete a Course");
                                                    Console.WriteLine("Enter [3] to Attemp Test");
                                                    Console.WriteLine("Enter [4] to View Course Completion Certificate");
                                                    Console.WriteLine("Enter [5] to go back to Login Menu");
                                                    Console.WriteLine();
                                                    Console.Write("Enter Learner Service to do: ");
                                                    int loginServiceOption = int.Parse(Console.ReadLine());
                                                    switch (loginServiceOption)//Validation For Learner Login
                                                    {
                                                        case 1:
                                                            {
                                                                //Course Enroll--Praveena
                                                                Console.WriteLine();
                                                                Console.WriteLine("----------------Enroll a Course-----------------");
                                                                course = new Course();
                                                                learnerServices = new LearnerServices();
                                                                Console.WriteLine("List of Courses");
                                                                Console.WriteLine();
                                                                learnerServices.GetCourseTitles();
                                                                Console.WriteLine();
                                                                Console.Write("Enter Course Title to Enroll: ");
                                                                course.CourseTitle = Console.ReadLine();
                                                                learnerServices.EnrollCourse(user, course);

                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                //Complete the Course--Praveena
                                                                Console.WriteLine();
                                                                Console.WriteLine("----------------Take the Course-----------------");
                                                                learnerServices = new LearnerServices();
                                                                Console.WriteLine("Here is the List of Courses you have Enrolled");
                                                                learnerServices.GetEnrolledCourses(user.UserEmail);
                                                                Console.Write("Enter Course Title to Complete: ");
                                                                learnerServices.CompleteCourse(user, Console.ReadLine());
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                //Taking Test--Sai Kiran
                                                                Console.WriteLine();
                                                                Console.WriteLine("----------------Test Page-----------------");
                                                                learnerServices = new LearnerServices();
                                                                Console.WriteLine("Want to Take Test?");
                                                                Console.WriteLine("Here is the List Of courses you completed. Please Enter Course Title to take Test");
                                                                learnerServices.GetCompletedCourses(user.UserEmail);
                                                                Console.Write("Enter Course Name To take Test: ");
                                                                /*Console.WriteLine();*/
                                                                string CourseTitle = Console.ReadLine();
                                                                learnerServices.StartTest(user.UserEmail, CourseTitle);
                                                                //int questionCount = learnerServices.GetQuestionCount(CourseTitle);
                                                                List<string> Questions = learnerServices.GetQuestions(CourseTitle);
                                                                List<string> Answers = new List<string>();
                                                                Console.WriteLine();
                                                                Console.WriteLine("No. Of Questions you have in this Test: " + Questions.Count);
                                                                for (int i = 0; i < Questions.Count; i++)
                                                                {
                                                                    Console.WriteLine((i + 1) + "." + Questions[i]);
                                                                    Console.Write("Type Answer: ");
                                                                    Answers.Add(Console.ReadLine());

                                                                }
                                                                learnerServices.SubmitTest(Answers, CourseTitle, user.UserEmail);
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                //Course Completetion Certificate--Praveena
                                                                Console.WriteLine();
                                                                Console.WriteLine("----------------View Certificate Page-----------------");
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
                                                            goto LoginMenu;
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
                                Console.WriteLine();
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
                                goto MainMenu;
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
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                /*string path = @"C:\Error.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("--------------Error Logging------------");
                    writer.WriteLine("Date:" + DateTime.Now.ToString());
                    writer.WriteLine("Message:" + e.Message);

                }*/
            }
            
        }
    }
}

