using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment_30533651.Models;

namespace FIT5032_Assignment_30533651.Controllers
{
    public class BranchCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BranchCourses
         public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var branchCourses = db.BranchCourses.Include(b => b.Branches).Include(b => b.Courses);
                return View(branchCourses.ToList());
            }
            else
            {
                var branchCourses = db.BranchCourses.Include(b => b.Branches).Include(b => b.Courses);
                return View("UserIndex", branchCourses.ToList());
            }

        }

        // GET: BranchCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchCourses branchCourses = db.BranchCourses.Find(id);
            branchCourses.Branches = db.Branches.Find(branchCourses.BranchesId);
            branchCourses.Courses = db.Courses.Find(branchCourses.CoursesId);
            if (branchCourses == null)
            {
                return HttpNotFound();
            }
            return View(branchCourses);
        }

        // GET: BranchCourses/Create
        public ActionResult Create()
        {
            ViewBag.BranchesId = new SelectList(db.Branches, "Id", "Name");
            ViewBag.CoursesId = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        // POST: BranchCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BranchesId,CoursesId,StartTime")] BranchCourses branchCourses)
        {
            if (ModelState.IsValid)
            {
                db.BranchCourses.Add(branchCourses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchesId = new SelectList(db.Branches, "Id", "Name", branchCourses.BranchesId);
            ViewBag.CoursesId = new SelectList(db.Courses, "Id", "Name", branchCourses.CoursesId);
            return View(branchCourses);
        }

        // GET: BranchCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchCourses branchCourses = db.BranchCourses.Find(id);
            if (branchCourses == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchesId = new SelectList(db.Branches, "Id", "Name", branchCourses.BranchesId);
            ViewBag.CoursesId = new SelectList(db.Courses, "Id", "Name", branchCourses.CoursesId);
            return View(branchCourses);
        }

        // POST: BranchCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BranchesId,CoursesId,StartTime")] BranchCourses branchCourses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branchCourses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchesId = new SelectList(db.Branches, "Id", "Name", branchCourses.BranchesId);
            ViewBag.CoursesId = new SelectList(db.Courses, "Id", "Name", branchCourses.CoursesId);
            return View(branchCourses);
        }

        // GET: BranchCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BranchCourses branchCourses = db.BranchCourses.Find(id);
            if (branchCourses == null)
            {
                return HttpNotFound();
            }
            return View(branchCourses);
        }

        // POST: BranchCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BranchCourses branchCourses = db.BranchCourses.Find(id);
            db.BranchCourses.Remove(branchCourses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET BranchCourses/CoursesByBranch/id
        public ActionResult CoursesByBranch(int id)
        {
            // id: branchId
            ViewBag.branch = db.Branches.FirstOrDefault(b => b.Id == id);
            var branchCourses = db.BranchCourses.Include(be => be.Branches).Include(be => be.Courses).Where(be => be.BranchesId == id).ToList();
            return View(branchCourses);
        }

        // GET BranchCourses/GetCoursesByBranch/id
        public JsonResult GetCoursesByBranch(int id)
        {
            var branchCourses = db.BranchCourses.Include(be => be.Branches).Include(be => be.Courses).Where(be => be.BranchesId == id).ToList();
            return new JsonResult { Data = branchCourses, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
