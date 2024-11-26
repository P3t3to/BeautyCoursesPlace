using BeautyCoursesPlace.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Infrastructure.Data.SeedDb
{
    internal class LectorConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> builder)
        {
            var data = new SeedData();

            builder.HasData(new Lector[] {data.Lector});
        }
    }
}
