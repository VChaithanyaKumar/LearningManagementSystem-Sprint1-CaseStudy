using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DAL
{
    interface ILearnerRepository
    {
        void EnrollCourse(string UserEmail, string CourseTitle);
    }
}
