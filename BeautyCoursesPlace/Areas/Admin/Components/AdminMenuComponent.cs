﻿using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Areas.Admin.Components
{
    public class AdminMenuComponent:ViewComponent
    {
        
        public async Task<IViewComponentResult>InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());  
        }
    }
}
