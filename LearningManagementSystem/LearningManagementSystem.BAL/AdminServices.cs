using System;
using System.Collections.Generic;
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
    }
}
