using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Exeptions
{
    public class UnauthorizedExeption : Exception
    {
        public UnauthorizedExeption()
        {

        }

        public UnauthorizedExeption(string message)
            : base(message) { }
    }
}
