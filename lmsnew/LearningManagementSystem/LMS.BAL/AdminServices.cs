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
        public void UpdatePassword(string UserEmail,string OldPassword,string NewPassword)
        {
            try
            {
                adminRepository.UpdateUser(UserEmail, OldPassword, NewPassword);
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
        public void AssignCourse(string UserEmail,string CourseTitle)
        {

            try
            {
                adminRepository.AssignCourse(UserEmail, CourseTitle);
                Console.WriteLine("User is assigned to Course Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Entered User Email or CourseId is wrong.");
                
            }
           
        }

        //Admin Services related to Courses
        //update course description details
        public void UpdateCourseDescription(Course course)
        {
            adminRepository.UpdateCourseDescription(course);

        }
        //update course outcome details
        public void UpdateCourseOutCome(Course course)
        {
            adminRepository.UpdateCourseOutComes(course);

        }
        //adding new course
        public void AddCourse(Course course)
        {
            adminRepository.AddCourse(course);

        }
        //adding questions to new course
        public void AddCourseQuestion(Question question, Course course)
        {
            adminRepository.AddCourseQuestion(question, course);
        }
        //get all course titles
        public void GetCourseTitles()
        {
            int i = 1;
            List<string> course = adminRepository.GetCourseTitles();
            course.ForEach(value => Console.WriteLine((i++) + ". " + value));
        }
        //delete course
        public void DeleteCourse(string CourseTitle)
        {
            adminRepository.DeleteCourse(CourseTitle);
            Console.WriteLine("Course Deleted sucessfull");
        }
        //Get Course-status of particular user
        public void CourseStatus(decimal UserId)//userId need to decimal
        {
            ArrayList courseStatus = adminRepository.CourseStatus(UserId);
            foreach (var s in courseStatus)
            {
                Console.WriteLine($"{s}");
            }
        }
        //Generate report of particular user
        public void GenearteReport(string UserEmail)
        {
            ArrayList records = adminRepository.GenerateReport(UserEmail);
            if (records is not null)
            {
                foreach (var r in records)
                {
                    Console.WriteLine($"{r}");


                } 
            }
            else
            {
                Console.WriteLine("No Records Available");
            }
        }
        public string GetPassword(string UserEmail)
        {
            return(adminRepository.GetPassword(UserEmail));
        }
    }
}
