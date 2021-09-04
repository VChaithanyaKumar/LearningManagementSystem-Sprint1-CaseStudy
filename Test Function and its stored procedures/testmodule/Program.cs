using System;
using System.Collections.Generic;
namespace testmodule
{
    class Program
    {
        static void Main(string[] args)
        {
            LearnerRepo repo = new LearnerRepo();
            Console.WriteLine("take test");
            Console.WriteLine("enter UserId");
            decimal UserId = decimal.Parse(Console.ReadLine());
            List<decimal> CompletedCourses= repo.CompletedCourses(UserId);

            for (int i = 0;i < CompletedCourses.Count;i++)
            {
                Console.WriteLine(CompletedCourses[i]);
            }
            Console.WriteLine("enter course id to start test");
            decimal CourseId = decimal.Parse(Console.ReadLine());
            repo.StartTest(UserId, CourseId);
            List<string> Answers = new List<string>();
            List<decimal> QuestionIds = new List<decimal>();
            int NoOfQuestions = repo.CourseQuestionNo(CourseId);
            /*Console.WriteLine(NoOfQuestions);*/
            List<decimal> QuestionId = repo.CourseQuestion(CourseId);
            /*for (int i = 0; i < QuestionId.Count; i++)
            {
                Console.WriteLine(QuestionId[i]);
            }*/
            
            for(int i=0;i<NoOfQuestions;i++)
            {
                Console.WriteLine(repo.GetQuestion(QuestionId[i]));
                Console.WriteLine("enter answer");
                Answers.Add(Console.ReadLine());
            }
            /*for(int i=0;i<Answers.Count;i++)
            {
                Console.WriteLine(Answers[i]);
            }*/
            List<decimal> Result = new List<decimal>();
            for(int i=0;i<Answers.Count;i++)
            {
                if(Answers[i]==repo.GetAnswer(QuestionId[i]))
                {
                    Result.Add(1);
                }
                else
                {
                    Result.Add(0);
                }
            }
            decimal correctans = 0;
            for (int i = 0; i < Result.Count; i++)
            {
                
                if(Result[i]==1)
                {
                    correctans++;
                }
                
            }
            decimal percentage = (correctans / Result.Count)*100;
            Console.WriteLine("Result="+percentage);
            repo.UpdateResult(UserId, CourseId, percentage);
        }
    }
}
