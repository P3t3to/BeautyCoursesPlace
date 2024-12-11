using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BeautyCoursesPlace.Core.Constants.RoleConstants;

namespace BeautyCoursesPlace.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
       
    }
}
