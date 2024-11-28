using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Constants
{
    public static class MessageConstants
    {
        public const string FillInMessage = "The {0} field must be filled in";

        public const string TelephoneMessage = "The {0} field should have a length between {2} and {1} digits.";

        public const string TelephoneAlreadyRegistered = "Phone number already exists in the system.";

        public const string SignInCourse = "You cannot become a lecturer because you are already enrolled in a course.";
    }
}

