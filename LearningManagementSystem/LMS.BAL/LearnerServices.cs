using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.DAL;
using System.Threading.Tasks;
using LearningManagementSystem.Entities;
namespace LMS.BAL
{
    public class LearnerServices
    {
        private LearnerRepository learnerRepository = new LearnerRepository();
        //Enrollment to course
        public void EnrollCourse(string UserEmail, string CourseTitle)
        {

            try
            {
                learnerRepository.EnrollCourse(UserEmail, CourseTitle);
                Console.WriteLine("User is Enrolled to Course Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
        //Get all course titles
        public void GetCourseTitles()
        {
            int i = 1;
            List<string> course = learnerRepository.GetCourseTitles();
            course.ForEach(value => Console.WriteLine((i++) +". " + value));
        }
        //Mark course as complete
        public void CompleteCourse(string UserEmail,string CourseTitle)
        {
            try
            {
                learnerRepository.CompleteCourse(UserEmail, CourseTitle);
                Console.WriteLine("Completed the Course Successfully!!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public void GetCompletedCourses(string UserEmail)
        {
            List<string> CompletedCourses=learnerRepository.GetCompletedCourses(UserEmail);
            for (int i = 0; i < CompletedCourses.Count; i++)
            {
                Console.WriteLine((i+1)+". "+CompletedCourses[i]);
            }
        }
        public void StartTest(string UserEmail,string CourseTitle)
        {
            learnerRepository.StartTest(UserEmail, CourseTitle);
        }
        public List<string> GetQuestions(string CourseTitle)
        {
            List<string> Questions = learnerRepository.GetQuestions(CourseTitle);
            return Questions;
        }
        public void SubmitTest(List<string> Answers,string CourseTitle,string UserEmail)
        {
            try
            {
                List<string> AnswerList = learnerRepository.GetAnswers(CourseTitle);
                float marks = 0;
                for (int i = 0; i < AnswerList.Count; i++)
                {
                    if (AnswerList[i].Equals(Answers[i], StringComparison.CurrentCultureIgnoreCase))
                        marks += 1;
                }
                //Console.WriteLine("marks: "+marks);
                //Console.WriteLine(AnswerList.Count);
                float Result = (marks / (float)AnswerList.Count) * 100;
                //Console.WriteLine(Result);
                learnerRepository.UpdateResult(UserEmail, CourseTitle, Result);
                Console.WriteLine("Submitted the test Successfully");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            

            
        }
        public void ViewSubmissionCertificate(string UserEmail,string CourseTitle)
        {
            double Result = learnerRepository.GetResult(UserEmail, CourseTitle);
            Console.WriteLine(Result);
            if (Result == 0)
            {
                Console.WriteLine("User has not Attempted the Test yet. Please Take the test");
                return;
            }
            User user = learnerRepository.GetUserDetails(UserEmail);
            if (Result > 60)
            {
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("             Course Completion Certificate               ");
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("Mr/Ms " + user.UserFirstName + " " + user.UserLastName + " Completed the Course '" + CourseTitle + "' Successfully!");
                Console.WriteLine("Percentage Obtained: " + Result);
                Console.WriteLine("_________________________________________________________________");
            }
            else
            {
                Console.WriteLine("User has not passed the test! Please Attempt your test again");
            }
        }
    }
}
