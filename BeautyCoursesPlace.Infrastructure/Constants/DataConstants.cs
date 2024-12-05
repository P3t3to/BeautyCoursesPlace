using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Infrastructure.Constants
{
    public static class DataConstants
    {
        
        public const int NameMaxLength = 50;

        public const int TitleMaxLength = 50;
        public const int TitleMinLength = 5;


        public const int AddressMaxLength = 200;
        public const int AddressMinLength = 5;

        public const int DescriptionMaxLength = 600;
        public const int DescriptionMinLength = 50;

        public const string CoursesCostMaxLength = "5000";
        public const string CoursesCostMinLength = "0";

        public const int TelephoneMaxLength = 15;
        public const int TelephoneMinLength = 10;


        //Partner
        public const int PartnerNameMaxLength = 30;
        public const int PartnerNamMinLength = 5;

        //Saloon
        public const int SaloonNameMaxLength = 30;
        public const int SaloonNamMinLength = 5;


        // ApplicationUser
        public const int UserFirstNameMax = 30;
        public const int UserFirstNameMin = 2;

        public const int UserLastNameMax = 30;
        public const int UserLastNameMin = 2;

    }
}
