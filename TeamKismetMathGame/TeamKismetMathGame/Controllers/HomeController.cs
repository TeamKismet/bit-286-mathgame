using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamKismetMathGame.Models;

namespace TeamKismetMathGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdditionPage()
        {
            AdditionQuestion add = new AdditionQuestion();

            int AP = 0;

            if(add.ACorrect == true)
            {
                AP += 5;
            }

            ViewBag.Message = "Your Addition page.";

            return View();
        }
    }
}