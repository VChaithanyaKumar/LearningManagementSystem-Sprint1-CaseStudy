using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testmodule
{
    public interface ILearnerRepo
    {
        List<decimal> CompletedCourses(decimal UserId);
        void StartTest(decimal UserId, decimal CourseId);
        int CourseQuestionNo(decimal CourseId);
        List<decimal> CourseQuestion(decimal CourseId);
        string GetQuestion(decimal QuestionId);
        string GetAnswer(decimal QuestionId);
        void UpdateResult(decimal UserId, decimal CourseId, decimal Percentage);
    }
}
