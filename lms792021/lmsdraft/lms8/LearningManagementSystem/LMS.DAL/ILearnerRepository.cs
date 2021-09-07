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
        void EnrollCourse(User user, Course course);
        List<string> GetCourseTitles();
        void CompleteCourse(User user, string CourseTitle);
        List<string> GetCompletedCourses(string UserEmail);
        void StartTest(string UserEmail, string CourseTitle);
        //int GetQuestionCount(string CourseTitle);
        List<string> GetQuestions(string CourseTitle);
        List<string> GetAnswers(string CourseTitle);
        void UpdateResult(string UserEmail, string CourseTitle, float Percentage);
        Result GetResult(User user, string CourseTitle);
        User GetUserDetails(string UserEmail);
        List<string> GetEnrolledCourses(string UserEmail);
        /*string GetSubmitDate(User user, string CourseTitle);*/
    }
}
