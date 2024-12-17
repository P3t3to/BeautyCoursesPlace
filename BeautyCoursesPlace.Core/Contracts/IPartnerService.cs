using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Partner;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface IPartnerService
    {

        Task<Partner> GetPartnerByIdAsync(int id);

        Task<IEnumerable<Partner>> GetAllPartnersAsync();

        

    }
}
    

