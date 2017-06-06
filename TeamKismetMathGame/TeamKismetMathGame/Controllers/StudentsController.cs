//Code By: Jonathan Lopez
//Class: BIT 286
//DATE: SPRING 2017

//NOTE: This is an auto-generated class based on the Student Model. There have been some code additions made to this file to add functionality for Student Login

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamKismetMathGame.Models;

namespace TeamKismetMathGame.Controllers
{
    public class StudentsController : Controller
    {
        private Kismet_InfoEntities db = new Kismet_InfoEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Geometry,Addition,Subtraction,TotalScore,Username")] Student student)
        {

            //Adds student to a new row in the database. Without this while loop the application crashes.
            while (db.Students.Find(student.Id) != null)
            {
                student.Id++;
            }

            //Adds new student to the database then clears the input field. 
            if (ModelState.IsValid)
            {
                using (Kismet_InfoEntities db = new Kismet_InfoEntities())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = student.FirstName + " " + student.LastName + " successfully registered.";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //Student Login View
        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }
        
        //Creates session for Student Login
        //Checks for the inputed student username in the database. If student username is matches then adds current user to the session and redirects to logged in page.
        [HttpPost]
        public ActionResult StudentLogin(Student student)
        {
            using (Kismet_InfoEntities db = new Kismet_InfoEntities())
            {
                var usr = db.Students.Where(u => u.Username == student.Username).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.Id.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "username is incorrect.");
                }
            }
            return View();
        }

        //Creates feedback view for successfull login
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("StudentLogin");
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Geometry,Addition,Subtraction,TotalScore,Username")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
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
