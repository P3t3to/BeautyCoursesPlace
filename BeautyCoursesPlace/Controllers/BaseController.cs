using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCoursesPlace.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
       
}
