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

        
        public void UpdateCourseDescription(Course course)
        {
            adminRepository.UpdateCourseDescription(course);

        }
        public void UpdateCourseOutCome(Course course)
        {
            adminRepository.UpdateCourseOutComes(course);

        }
        public void GetCourseTitles()
        {
            int i = 1;
            List<string> course = adminRepository.GetCourseTitles();
            course.ForEach(value => Console.WriteLine((i++) + ". " + value));
        }
        public void DeleteCourse(string CourseTitle)
        {
            adminRepository.DeleteCourse(CourseTitle);
        }
        public void CourseStatus(decimal UserId)//userId need to decimal
        {
            ArrayList courseStatus = adminRepository.CourseStatus(UserId);
            foreach (var s in courseStatus)
            {
                Console.WriteLine($"{s}");
            }
        }
        public void GenearteReport(string UserEmail)
        {
            ArrayList records = adminRepository.GenerateReport(UserEmail);
            foreach (var r in records)
            {
                Console.WriteLine($"{r}");



            }
        }
    }
}
