﻿using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeautyCoursesPlace.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public IQueryable<Course> Courses => context.Set<Course>();

        public Repository(BeautyCoursesDbContext _context)
        {
            context = _context;
        }


        private DbSet<T>DbSet<T>() where T : class 
        {
            return context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }


        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if(entity != null)
            {
                DbSet<T>().Remove(entity);
            }
        }

        public async Task<List<Saloon>> GetSaloonsByPartnerIdAsync(int partnerId)
        {
            return await DbSet<Saloon>()
                .Where(s => s.PartnerId == partnerId)
                .ToListAsync();
        }

        public async Task<Saloon?> GetSaloonByIdAsync(int saloonId)
        {
            return await DbSet<Saloon>()
                .FirstOrDefaultAsync(s => s.Id == saloonId);
        }

        public DbSet<T> Set<T>() where T : class
        {
            return context.Set<T>();
        }

        //public IQueryable<Course> AllCourses()
        //{
        //    return Set<Course>();
        //}

        public IQueryable<Course> AllCourses()
        {
            return context.Set<Course>(); 
        }



        public async Task<Partner> GetByIdAsync(int id)
        {
            return await context.Set<Partner>().FindAsync(id);
        }

        public IQueryable<Partner> Partners => context.Set<Partner>();
    }
}
