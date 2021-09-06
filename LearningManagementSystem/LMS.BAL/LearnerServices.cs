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
        public void EnrollCourse(User user, Course course)
        {

            try
            {
                List<string> courseTitles = learnerRepository.GetCourseTitles();
                if (courseTitles.Contains(course.CourseTitle))
                {
                    learnerRepository.EnrollCourse(user, course);
                    Console.WriteLine("User is Enrolled to Course Successfully!");
                }
                else
                {
                    Console.WriteLine("Entered Course is not present in the Course List Provided");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Entered Invalid Course.Please Try Again!!");
                Console.WriteLine(e.Message);

            }

        }
        //Get all course titles
        public void GetCourseTitles()
        {
            int i = 1;
            List<string> courseTitles = learnerRepository.GetCourseTitles();
            Console.WriteLine("Below are the available Courses. Please choose the Course to Enroll");
            courseTitles.ForEach(value => Console.WriteLine(value));
        }
        //Mark course as complete
        public void CompleteCourse(User user,string CourseTitle)
        {
            try
            {
                learnerRepository.CompleteCourse(user, CourseTitle);
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
                Console.WriteLine(CompletedCourses[i]);
            }
        }
        public void GetEnrolledCourses(string UserEmail)
        {
            List<string> EnrolledCourses = learnerRepository.GetEnrolledCourses(UserEmail);
            for (int i = 0; i < EnrolledCourses.Count; i++)
            {
                Console.WriteLine(EnrolledCourses[i]);
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

        //Submit test
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
                Console.WriteLine("Submitted the test Successfully! If you want to view your result please go to View Certification option");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            

            
        }
        public void ViewSubmissionCertificate(User user,string CourseTitle)
        {
            Result result = learnerRepository.GetResult(user, CourseTitle);
            //Console.WriteLine(Result);
            if (result==null)
            {
                Console.WriteLine("User has not Attempted the Test yet. Please Take the test");
                return;
            }
            user = learnerRepository.GetUserDetails(user.UserEmail);
            if (result.ResultDescription > 60)
            {
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("             Course Completion Certificate               ");
                Console.WriteLine("_________________________________________________________________");
                Console.WriteLine("Mr/Ms " + user.UserFirstName + " " + user.UserLastName + " Completed the Course '" + CourseTitle + "' Successfully!");
                Console.WriteLine("Percentage Obtained: " + result.ResultDescription);
                Console.WriteLine("_________________________________________________________________");
            }
            else
            {
                Console.WriteLine("The Percentage Obtained: " + result.ResultDescription);
                Console.WriteLine("You have not passed the test! Please Attempt your test again");
            }
        }
    }
}
