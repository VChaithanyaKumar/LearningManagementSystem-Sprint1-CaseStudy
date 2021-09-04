using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.DAL;
using System.Threading.Tasks;

namespace LMS.BAL
{
    class LearnerServices
    {
        private LearnerRepository learnerRepository = new LearnerRepository();
        public void AssignCourse(string UserEmail, string CourseTitle)
        {

            try
            {
                learnerRepository.EnrollCourse(UserEmail, CourseTitle);
                Console.WriteLine("User is Enrolled to Course Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Entered User Email or CourseId is wrong.");

            }

        }
    }
}
