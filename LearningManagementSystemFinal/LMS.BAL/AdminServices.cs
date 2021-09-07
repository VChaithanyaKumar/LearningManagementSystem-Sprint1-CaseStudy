using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using LMS.DAL;
using System.Threading.Tasks;
using LearningManagementSystem.Entities;
namespace LMS.BAL
{
    public class AdminServices
    {
        private AdminRepository adminRepository = new AdminRepository();
        //Admin Services related to User
        //update user password
        public void UpdatePassword(string UserEmail,string NewPassword)
        {
            try
            {
                adminRepository.UpdateUser(UserEmail, NewPassword);
                Console.WriteLine("Password Updated Successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Delete user
        public void DeleteUser(string UserEmail)
        {
            try
            {
                adminRepository.DeleteUser(UserEmail);
                Console.WriteLine("Deleted the User Successfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        //Assign user to course
        public void AssignCoursebyAdmin(string UserEmail,string CourseTitle)
        {

            try
            {
                adminRepository.AssignCoursebyAdmin(UserEmail, CourseTitle);
                Console.WriteLine("User is assigned to Course Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
           
        }

        //Admin Services related to Courses
        //update course description details
        public void UpdateCourseDescription(Course course)
        {
            try
            {
                adminRepository.UpdateCourseDescription(course);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //update course outcome details
        public void UpdateCourseOutCome(Course course)
        {
            try
            {
                adminRepository.UpdateCourseOutComes(course);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //adding new course
        public void AddCourse(Course course)
        {
            try
            {
                adminRepository.AddCourse(course);
                Console.WriteLine("Added the Course Successfully");
            }
            catch (Exception)
            {

                throw;
            }

        }
        //adding questions to new course
        public void AddCourseQuestion(Question question, Course course)
        {
            try
            {
                adminRepository.AddCourseQuestion(question, course);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //get all course titles
        public void GetCourseTitles()
        {

            try
            {
                List<string> course = adminRepository.GetCourseTitles();
                for (int i = 0; i < course.Count; i++)
                {
                    Console.WriteLine(course[i]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //delete course
        public void DeleteCourse(string CourseTitle)
        {
            try
            {
                adminRepository.DeleteCourse(CourseTitle);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Get Course-status of particular user
        public void CourseStatus(decimal UserId)//userId need to decimal
        {
            ArrayList courseStatus = adminRepository.CourseStatus(UserId);
            if (courseStatus != null)
            {
                foreach (var s in courseStatus)
                {
                    Console.WriteLine($"{s}");
                }
            }
            else
            {
                Console.WriteLine("The User is an Admin or the Learner has not Enrolled for any Course, Course status is not applicable");
            }
        }
        //Generate report of particular user
        public void GenearteReport()
        {
            try
            {
                ArrayList records = adminRepository.GenerateReport();
                foreach (var r in records)
                {
                    Console.WriteLine($"{r}");


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Get Password
        public string GetPassword(string UserEmail)
        {
            try
            {
                return (adminRepository.GetPassword(UserEmail));
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Get All Users Emails
        public void GetAllUserEmails()
        {
            try
            {
                List<string> UserEmails = adminRepository.GetAllUserEmails();
                for (int i = 0; i < UserEmails.Count; i++)
                {
                    Console.WriteLine(UserEmails[i]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Get UserIds and Emails
        public void GetUserIdEmail()
        {
            try
            {
                adminRepository.GetUserIdEmail();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
