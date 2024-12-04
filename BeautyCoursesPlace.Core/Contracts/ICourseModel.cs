using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Contracts
{
    public interface ICourseModel
    {

        public string Title { get; set; }

        public string Address { get; set; }
    }
}
