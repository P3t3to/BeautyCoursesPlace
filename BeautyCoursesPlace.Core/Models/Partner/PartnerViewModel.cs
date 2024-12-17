﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Models.Partner
{
    public class PartnerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Address { get; set; } // Добавено свойство за адрес
        public List<string> Courses { get; set; } = new List<string>(); // Добавено свойство за курсове
        public List<string> Saloons { get; set; } = new List<string>(); // Добавено свойство за салони
    }
}