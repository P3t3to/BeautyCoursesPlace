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

            // Преобразуваме Saloon в SaloonViewModel
            return saloons.Select(s => new SaloonViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                //PartnerName = s.Partner.Name // Получаваме името на партньора от свързания обект Partner
            }).ToList();
        }


     

        public async Task<bool> UserHasSaloonAsync(string userId)
        {
            // Проверяваме дали съществува салон, свързан с userId
            return await repository.All<Saloon>()
                .AnyAsync(s => s.UserId == userId);  // Предполагаме, че Saloon има UserId
        }




        public async Task<int>CreateSaloonAsync(SaloonViewModel model, string userId)
        {
            // Създаване на нов партньор за потребителя, ако такъв не съществува
            var partner = new Partner
            {
                UserId = userId,
                Name = model.Name,  // Може да добавиш още полета за партньора, ако е необходимо
                Address = model.Address,  // Може да използваш адреса на салона за партньора
                ImageUrl = "default-image-url"  // Ако има изображение за партньора
            };

            // Добавяме партньора в базата данни
            await repository.AddAsync(partner);
            await repository.SaveChangesAsync();

            // Създаване на нов салон
            var saloon = new Saloon
            {
                Name = model.Name,
                Address = model.Address,
                PartnerId = partner.Id  // Свързваме партньора със салона
            };

            // Добавяме салона в базата данни
            await repository.AddAsync(saloon);

            // Записваме промените в базата данни
            await repository.SaveChangesAsync();

            return saloon.Id;
        }

        public async Task<Saloon> GetSaloonByIdAsync(int id)
        {
            return await repository.All<Saloon>().FirstOrDefaultAsync(s => s.Id == id);
        }
        

        public class SaloonResult
        {
            public bool IsSuccess { get; set; }
            public int SaloonId { get; set; }
        }


        //public async Task<bool> UserHasSaloonAsync(string userId)
        //{
        //    return (await repository.GetSaloonsByPartnerIdAsync(int.Parse(userId))).Any(); 
        //}

        //public async Task<List<Saloon>> GetSaloonsByPartnerIdAsync(int partnerId)
        //{
        //    return await repository.GetSaloonsByPartnerIdAsync(partnerId);
        //}
    }
}
