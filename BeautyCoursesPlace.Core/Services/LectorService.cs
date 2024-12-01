using BeautyCoursesPlace.Core.Contracts;
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
    public class LectorService : ILectorService
    {
        private readonly IRepository repository;

        public LectorService(IRepository _repository)
        {
           repository=_repository;
        }

        public async Task<bool> ClientPhoneNumberExistAsync(string phoneNumber)
        {
           return await repository.AllReadOnly<Lector>()
                .AnyAsync(l=>l.Telephone==phoneNumber);
        }

        public async Task<bool> ClientSignInAsync(string userId)
        {
           return await repository.AllReadOnly<Course>()
                .AnyAsync(c=>c.StudentId == userId);
        }

        public async Task<bool> ExistByIdAsync(string userid)
        {
           return await repository.AllReadOnly<Infrastructure.Data.Models.Lector>()
                .AnyAsync(l => l.UserId == userid);
        }

        public async Task<int?> GiveLectorIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Lector>()
                .FirstOrDefaultAsync(l => l.UserId == userId))?.Id;
        }

        public async Task InitiateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Lector()
            {
                UserId = userId,
                Telephone = phoneNumber

            });

            await repository.SaveChangesAsync();
        }
    }
}
