using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Entities
{
    public class Question
    {
        public decimal QuestionId { get; set; }
        public decimal CourseId { get; set; }
        public string QuestionDescription { get; set; }
        public string AnswerDescription { get; set; }


    }
}
