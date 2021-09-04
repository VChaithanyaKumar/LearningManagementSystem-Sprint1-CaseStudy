using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Entities;

namespace LMS.DAL
{
    interface ILearnerRepository
    {
        void EnrollCourse(string UserEmail, string CourseTitle);
        List<string> GetCourseTitles();
    }
}
