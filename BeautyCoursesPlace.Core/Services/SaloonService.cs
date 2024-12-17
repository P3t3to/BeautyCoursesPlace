using BeautyCoursesPlace.Core.Contracts;
using BeautyCoursesPlace.Core.Models.Saloon;
using BeautyCoursesPlace.Infrastructure.Data;
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
    public class SaloonService : ISaloonService
    {

        private readonly IRepository repository;

        public SaloonService(IRepository _repository)
        {
            repository = _repository;

        }


        public async Task<List<SaloonViewModel>> GetSaloonsByPartnerIdAsync(int partnerId)
        {
            var saloons = await repository.GetSaloonsByPartnerIdAsync(partnerId);

           
            return saloons.Select(s => new SaloonViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                
            }).ToList();
        }




        public async Task<bool> UserHasSaloonAsync(string userId)
        {
           
            return await repository.All<Saloon>()
                .AnyAsync(s => s.UserId == userId);  
        }




        public async Task<int> CreateSaloonAsync(SaloonViewModel model, string userId)
        {
          
            var partner = new Partner     // Създаване на нов партньор за потребителя
            {
                UserId = userId,
                Name = model.Name,  
                Address = model.Address,  
                ImageUrl = "default-image-url"  
            };

           
            await repository.AddAsync(partner);
            await repository.SaveChangesAsync();

                                        
            var saloon = new Saloon     // Създаване на нов салон
            {
                Name = model.Name,
                Address = model.Address,
                PartnerId = partner.Id  // Свързваме партньора със салона
            };

           
            await repository.AddAsync(saloon);

            
            await repository.SaveChangesAsync();

            return saloon.Id;
        }

        public async Task<Saloon> GetSaloonByIdAsync(int id)
        {
            return await repository.All<Saloon>().FirstOrDefaultAsync(s => s.Id == id);
        }


    }




      
}
