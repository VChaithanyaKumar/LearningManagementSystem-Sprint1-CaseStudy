using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Entities
{
    public class CourseEnroll
    {
        public decimal EnrollId { get; set; }
        public decimal UserId { get; set; }
        public decimal CourseId { get; set; }
        public DateTime DateOfEnrollment { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public bool CourseStatus { get; set; }
        
    }
}
