using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.DAL;
using System.Threading.Tasks;

namespace LMS.BAL
{
    public class AdminServices
    {
        private AdminRepository adminRepository = new AdminRepository();
        public void AssignCourse(string UserEmail,string CourseTitle)
        {

            try
            {
                adminRepository.AssignCourse(UserEmail, CourseTitle);
                Console.WriteLine("User is assigned to Course Successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Entered User Email or CourseId is wrong.");
                
            }
           
        }
    }
}
