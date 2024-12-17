using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Partner;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Services
{
    public class PartnerService : IPartnerService

    {
        private readonly IRepository repository;

        public PartnerService(IRepository _repository)
        {
            repository = _repository;

        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            return await repository.All<Partner>()
                .Include(p => p.Courses)
                .Include(p => p.Saloons)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Partner>> GetAllPartnersAsync()
        {
            return await repository.All<Partner>().ToListAsync();
        }
    }
}




