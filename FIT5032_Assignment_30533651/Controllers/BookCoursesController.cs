using FIT5032_Assignment_30533651.Models;
using FIT5032_Assignment_30533651.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Assignment_30533651.Controllers
{
    public class BookCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: BookCourses
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Customer")]
        public ActionResult Book (int id)
        {
            // id = branch Courses Id
            //var user = db.Users.Find(User.Identity.GetUserId());
            var branchCourses = db.BranchCourses.Where(be => be.Id == id).FirstOrDefault();
            //var branchCourses = db.BookCourses.Where(be => be.Id == id).FirstOrDefault();
            var userId = User.Identity.GetUserId();
            var check = db.BookCourses.Where(be => be.BranchCoursesId == id && be.ApplicationUserId.Equals(userId)).FirstOrDefault();
            if (check == null)
            {

                var bookCourses = new BookCourses { ApplicationUserId = User.Identity.GetUserId(), BranchCoursesId = id };
                db.BookCourses.Add(bookCourses);
                db.SaveChanges();

                string toEmail = User.Identity.GetUserName();
                string subject = "Book Course Confirm";
                string content = "Successfully booked the course. Start time:" + branchCourses.StartTime.ToString();

                EmailSender es = new EmailSender();
                es.Send(toEmail, subject, content);

            }
            else
            {
                ViewBag.Error = "You have already bookend this Course!";
                // return error page
            }

            return View("index");
        }
    }
}