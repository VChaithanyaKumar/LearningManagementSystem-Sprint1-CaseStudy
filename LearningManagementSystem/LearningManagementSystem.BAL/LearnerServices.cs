﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.DAL;
using System.Threading.Tasks;

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
    }
}
