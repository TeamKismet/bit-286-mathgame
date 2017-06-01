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

        public ActionResult StudentLogin()
        {
            return View();
        }
        public ActionResult TeacherLogin()
        {
            return View();
        }

        public ActionResult AdditionPage(AdditionQuestion add)
        {
            Random rng = new Random();

            if (add.AddVariable == null)
            {
                add.AddVariable = rng.Next(1, 11);
            }

            int V1 = add.AddVariable.Value;

            ViewBag.RNG = add.AddVariable;

            if (add.AddAnswer == null)
            {
                add.AddAnswer = rng.Next(V1 + 1, V1 + 10);
            }

            int V2 = add.AddAnswer.Value;

            ViewBag.Answer = V2;

            int AP = add.AdditionSkillCounter;

            ViewBag.QA = add.AddInput;

            Session["addvariable"] = add.AddVariable;

            Session["input"] = add.AddInput;

            if (add.AddInput == (int)Session["V2"] - (int)Session["V1"])
            {
                AP += 5;
                return RedirectToAction("AnswerPage");
            }

            Session["V1"] = add.AddVariable;

            Session["V2"] = add.AddAnswer;

            ViewBag.AP = AP;
            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Addition page.";

            return View();
        }

        public ActionResult SubtractionPage( SubtractionQuestion sub)
        {
            Random rng = new Random();

            if (sub.SubVariable == null)
            {
                sub.SubVariable = rng.Next(1, 11);
            }

            int V1 = sub.SubVariable.Value;

            ViewBag.RNG = sub.SubVariable;

            if (sub.SubAnswer == null)
            {
                sub.SubAnswer = rng.Next(V1 + 1, V1 + 10);
            }

            int V2 = sub.SubAnswer.Value;

            ViewBag.Answer = V2;

            int AP = sub.SubSkillCounter;

            ViewBag.QA = sub.SubInput;

            if (sub.SubInput == V2 - V1)
            {
                AP += 5;
                return View("AnswerPage");
            }

            ViewBag.AP = AP;

            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Subtraction page.";
            return View();
        }

        public ActionResult AnswerPage()
        {
            //int AP = 0;

            //int V2 = (int)Session["V2"];

            //int V1 = (int)Session["V1"];

            ViewBag.QA = (int)Session["input"];

            ViewBag.test = (int)Session["addvariable"];

            //if (ViewBag.QA == V2 - V1)
            //{
            //    AP += 5;
            //    return View("AnswerPage");
            //}
            return View();
        }
    }
}