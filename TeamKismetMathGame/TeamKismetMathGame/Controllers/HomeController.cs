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

        //msdn session data .net core
        /// <summary>
        /// httpget for addition page
        /// consider session data for question use counter.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult AdditionPage()
        {
            AdditionQuestion add = new AdditionQuestion();
            Random rng = new Random();
            add.AddVariable = rng.Next(1, 11);
            int V1 = add.AddVariable.Value;
            add.AddAnswer = rng.Next(V1 + 1, V1 + 10);
            int V2 = add.AddAnswer.Value;
            add.AdditionSkillCounter = 0;

            ViewBag.QA = add.AddInput;

            Session["AddVariable"] = add.AddVariable.Value;
            Session["AddAnswer"] = add.AddAnswer.Value;
            //Session["AddInput"] = add.AddInput.Value;
            Session["AddSkill"] = add.AdditionSkillCounter;

            return RedirectToAction("AdditionPage", "Home", add);
        }

        [HttpPost]
        public ActionResult AdditionPage( AdditionQuestion add )
        {
            ViewBag.RNG = Session["AddVariable"];
            int V1 = Int32.Parse(Session["AddVariable"].ToString());

            ViewBag.Answer = Session["AdedAnswer"];
            int V2 = Int32.Parse(Session["AddAnswer"].ToString());

            add.AddInput = ViewBag.QA;
            int QA = Int32.Parse(Session["AddInput"].ToString());

            int AP = add.AdditionSkillCounter;

            if (QA == V2 - V1)
                {
                    AP += 5;
                    return RedirectToAction("AnswerPage");
                }

            ViewBag.AP = add.AdditionSkillCounter;
            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Addition page.";

            return RedirectToAction("AdditionPage", "Home");
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
            ViewBag.AP = 5;

            ViewBag.SP = 5;
            //int V2 = ViewBag.Answer;

            //int V1 = ViewBag.RNG;

            //if (ViewBag.QA == V2 - V1)
            //{
            //    AP += 5;
            //    return View("AnswerPage");
            //}
            return View();
        }
    }
}