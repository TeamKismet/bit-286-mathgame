//Code By: Jonathan Lopez
//Class: BIT 286
//DATE: SPRING 2017

//NOTE: This is an auto-generated class based on the Student Model. There have been some code additions made to this file to add functionality for Teacher Login

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamKismetMathGame.Models;

namespace TeamKismetMathGame.Views.Teachers
{
    public class TeachersController : Controller
    {
        private Kismet_InfoEntities db = new Kismet_InfoEntities();

        // GET: Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Username,Password,ConfirmPassword")] Teacher teacher)
        {
            //Add teacher to new row in the database. This loop is needed to prevent database from crashing.
            while (db.Teachers.Find(teacher.Id) != null)
            {
                teacher.Id++;
            }

            //Adds new teacher to the database, clears input fields, then creats a feedback message upon successfuly registration.
            if (ModelState.IsValid)
            {
                using (Kismet_InfoEntities db = new Kismet_InfoEntities())
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = teacher.FirstName + " " + teacher.LastName + " successfully registered.";
            }

            return View(teacher);
        }

        //Create default view for Teacher Login
        [HttpGet]
        public ActionResult TeacherLogin()
        {
            return View();
        }

        //POST request for Teacher login, add teacher to session
        [HttpPost]
        public ActionResult TeacherLogin(Teacher teacher)
        {
            using (Kismet_InfoEntities db = new Kismet_InfoEntities())
            {
                var usr = db.Teachers.Where(u => u.Username == teacher.Username && u.Password == teacher.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.Id.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "username or Password is incorrect.");
                }
            }
            return View();
        }

        //Create view for feedback page successful login
        //If Teacher hasn't been successfully added to the session then it redirects back to the Teacher Login page.
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("TeacherLogin");
            }
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Username,Password,ConfirmPassword")] Teacher teacher)
        {
            while (db.Students.Find(teacher.Id) != null)
            {
                teacher.Id++;
            }

            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
