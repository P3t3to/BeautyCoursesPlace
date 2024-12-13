using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyCoursesPlace.Infrastructure.Constants.DataConstants;

namespace BeautyCoursesPlace.Infrastructure.Data.Models
{
    public class Saloon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SaloonNameMaxLength)]
        [Comment("Saloon name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Saloon address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int PartnerId { get; set; }


        [ForeignKey(nameof(PartnerId))]
        public virtual Partner Partner { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;
    }
}
