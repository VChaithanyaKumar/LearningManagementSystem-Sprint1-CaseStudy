using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LMS.BAL.Validations
{
    public class UserInputValidations
    {
        public static bool IsEmptyInput(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }
            else
                return false;
        }
        public static bool IsValidName(string input)
        {
            string pattern = @"[A-Z][a-zA-Z]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                return true;
            }
            else
                return false;
        }
    }
}
