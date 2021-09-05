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
        void CompleteCourse(string UserEmail, string CourseTitle);
        List<string> GetCompletedCourses(string UserEmail);
        void StartTest(string UserEmail, string CourseTitle);
        //int GetQuestionCount(string CourseTitle);
        List<string> GetQuestions(string CourseTitle);
        List<string> GetAnswers(string CourseTitle);
        void UpdateResult(string UserEmail, string CourseTitle, float Percentage);
        double GetResult(string UserEmail, string CourseTitle);
        User GetUserDetails(string UserEmail);
    }
}
