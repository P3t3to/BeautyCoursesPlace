using BeautyCoursesPlace.Core.Models.Saloon;
using BeautyCoursesPlace.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface ISaloonService
    {
        Task<bool> UserHasSaloonAsync(string userId);

        Task<List<SaloonViewModel>> GetSaloonsByPartnerIdAsync(int partnerId);

        Task<int> CreateSaloonAsync(SaloonViewModel model, string userId);

        Task<Saloon> GetSaloonByIdAsync(int id);
    }
}
