using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface ILectorService
    {
        Task<bool>ExistByIdAsync(string id);

        Task<bool> ClientPhoneNumberExistAsync(string phoneNumber);

        Task<bool> ClientSignInAsync(string userId);

        Task InitiateAsync(string userId, string phoneNumber);
    }
}
