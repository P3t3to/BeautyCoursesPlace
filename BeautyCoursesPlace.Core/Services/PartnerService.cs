using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Course;
using BeautyCoursesPlace.Core.Models.Partner;
using BeautyCoursesPlace.Infrastructure.Data.Common;
using BeautyCoursesPlace.Infrastructure.Data.Models;
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



        //public async Task<IEnumerable<PartnerViewModel>> FooterPartners()

        //{

        //    return await repository.AllReadOnly<Partner>()

        //       .Select(p => new PartnerViewModel()

        //       {

        //           Id = p.Id,

        //           Name = p.Name,

        //           ImageUrl = p.ImageUrl,

        //       })

        //       .ToListAsync();

        //}

        public async Task<IEnumerable<PartnerViewModel>> FooterPartners()

        {

            return await repository.AllReadOnly<Partner>()

               .Select(p => new PartnerViewModel()

               {

                   Id = p.Id,

                   Name = p.Name,

                   ImageUrl = p.ImageUrl,

               })

               .ToListAsync();

        }






        //public async Task<IEnumerable<PartnerViewModel>> FooterPartners()
        //{
        //    var query = repository.AllReadOnly<Partner>()
        //        .Select(p => new PartnerViewModel
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            ImageUrl = p.ImageUrl
        //        });

        //    // Извеждаме SQL заявката в конзолата
        //    Console.WriteLine(query.ToQueryString());

        //    return await query.ToListAsync();
        //}


    }
}




