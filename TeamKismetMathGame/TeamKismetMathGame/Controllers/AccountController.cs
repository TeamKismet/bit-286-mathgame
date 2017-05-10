using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamKismetMathGame.Models;

namespace TeamKismetMathGame.Controllers
{
    public class AccountController : Controller
    {
        //private Kismet_InfoEntities db = new Kismet_InfoEntities();

        //// GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: TeacherLogin
        //[HttpGet]
        //public ActionResult TeacherLogin()
        //{
        //    return View();
        //}

        //// POST: TeacherLogin
        //[HttpPost]
        //public ActionResult TeacherLogin(Teacher user)
        //{
        //    if (isUser(user.UserName))
        //    {
        //        Activity newActivity = new Activity();
        //        newActivity.ActivityDate = DateTime.Now;
        //        newActivity.ActivityName = user.UserName;
        //        db.Activities.Add(newActivity);
        //        db.SaveChanges();

        //        return View("./HomeController/Index", db.Activities);
        //    }

        //    else
        //    {
        //        ModelState.Clear();
        //        ModelState.AddModelError("ErrorMessage", "Your login attempt was not successful. Please try again.");

        //        return View("Login");
        //    }
        //}

        ////GET: New Account
        //[HttpGet]
        //public ActionResult NewAccount()
        //{
        //    NewAccountViewModel NewUserAccount = new NewAccountViewModel();
        //    return View("NewAccount", NewUserAccount);
        //}

        ////POST: New Account
        //[HttpPost]
        //public ActionResult NewAccount(NewAccount nAccount, string create, string reset)
        //{
        //    if (!string.IsNullOrEmpty(create))
        //    {
        //        if (!isUser(nAccount.FirstName))
        //        {
        //            User newUser = new User();

        //            newUser.FirstName = nAccount.FirstName;
        //            newUser.LastName = nAccount.LastName;
        //            Session["tempUser"] = newUser;

        //            return View();
        //        }

        //        else
        //        {
        //            return View("NewAccount");
        //        }
        //    }

        //    else
        //    {
        //        ModelState.Clear();
        //        return View("NewAccount");
        //    }
        //}

        //private bool isUser(string user)
        //{
        //    return db.Users.ToList().Any(m => m.Email == user);
        //}

        ///**
        // * Store temporary user in Session during account creation
        // */
        //private User GetTempUser()
        //{
        //    if (Session["tempUser"] == null)
        //    {
        //        Session["tempUser"] = new User();
        //    }
        //    return (User)Session["tempUser"];
        //}

        //private void FlushTempUser()
        //{
        //    Session.Remove("tempUser");
        //}
    }
}