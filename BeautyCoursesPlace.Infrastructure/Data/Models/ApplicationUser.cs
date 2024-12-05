using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Infrastructure.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [PersonalData]
        [MaxLength(UserFirstNameMax)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [PersonalData]
        [MaxLength(UserLastNameMax)]
        public string LastName { get; set; } = string.Empty;
    }
}
