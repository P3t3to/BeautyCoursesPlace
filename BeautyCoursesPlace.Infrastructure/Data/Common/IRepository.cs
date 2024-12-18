﻿using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task DeleteAsync<T>(object id) where T : class;

        Task<List<Saloon>> GetSaloonsByPartnerIdAsync(int partnerId);

        Task<Saloon?> GetSaloonByIdAsync(int saloonId);

        public DbSet<T> Set<T>() where T : class;

        IQueryable<Course> AllCourses();

        IQueryable<Course> Courses { get; }

        IQueryable<Partner> Partners { get; }
        Task<Partner> GetByIdAsync(int id);




    }
}
