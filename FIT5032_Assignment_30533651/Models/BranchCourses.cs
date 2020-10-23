using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment_30533651.Models
{
    public class BranchCourses
    {
        public int Id { get; set; }


        public Branches Branches { get; set;}
        public int BranchesId { get; set; }

        public Courses Courses { get; set; }
        public int CoursesId { get; set; }

        public DateTime StartTime { get; set; }


    }
}