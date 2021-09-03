using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem.Entities
{
    public class Author
    {
        public decimal AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public char Gender { get; set; }
        public string AuthorEmail { get; set; }

    }
}
