using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Partner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface IPartnerService
    {

        Task<IEnumerable<PartnerViewModel>> FooterPartners();



    }
}
    

