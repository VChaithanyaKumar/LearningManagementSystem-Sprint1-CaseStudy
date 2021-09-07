using System;

namespace LearningManagementSystem.Entities
{
    public class User
    {
        public string UserType { get; set; }
        public decimal UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public char Gender { get; set; }

    }
}
