using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Entities;
namespace LMS.DAL
{
    interface IAdminRepository
    {
        void AssignCourse(string UserEmail, string CourseTitle);
        //List<CourseEnroll> GenerateReport(string UserEmail);
        void UpdateCourseDescription(Course course);
        void UpdateCourseOutComes(Course course);
        List<string> GetCourseTitles();
    }
}
