using BeautyCoursesPlace.Core.Contracts;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BeautyCoursesPlace.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICourseModel course)
        {
            string info = course.Title.Replace(" ","-")+Getaddress(course.Address);
            info= Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string Getaddress(string address)
        {
          address = string.Join("-", address.Split(" ").Take(3));

            return address;
        }
    }
}
