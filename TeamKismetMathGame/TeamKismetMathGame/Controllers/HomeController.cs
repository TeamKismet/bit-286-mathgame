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
            Random rng = new Random();

            int V1 = rng.Next(1, 11);

            ViewBag.RNG = V1;

            int V2 = rng.Next(V1, V1 + 10);

            ViewBag.Answer = V2;

            AdditionQuestion add = new AdditionQuestion();

            int AP = 0;

            ViewBag.AP = AP;

            if (ViewBag.QA == V2 - V1)
            {
                AP += 5;
            }

            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Addition page.";

            return View();
        }

        public ActionResult SubtractionPage()
        {
            Random rng = new Random();

            int VS1 = rng.Next(0, 11);

            VS1 += 10;

            ViewBag.RNG = VS1;

            int VS2 = rng.Next(VS1 - 10, VS1);

            ViewBag.Answer = VS2;

            SubtractionQuestion add = new SubtractionQuestion();

            int AP = 0;

            ViewBag.AP = AP;

            if (ViewBag.QSA == VS2 - VS1)
            {
                AP += 5;
            }

            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Subtraction page.";
            return View();
        }
    }
}