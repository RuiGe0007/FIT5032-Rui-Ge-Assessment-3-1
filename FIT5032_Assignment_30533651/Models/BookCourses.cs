using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment_30533651.Models
{
    public class BookCourses
    {
        public int Id { get; set; }
        public BranchCourses BranchCourses { get; set; }
        public int BranchCoursesId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
     }
}