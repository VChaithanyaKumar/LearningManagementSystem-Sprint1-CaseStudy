using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningManagementSystem.Entities;
namespace LMS.DAL
{
    interface ILoginRepository
    {
        User GetLoginDetails(string userName);
    }
}
