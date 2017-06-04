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
            ViewBag.Message = "Basic information about 1st Grade Simulator 2017.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Currently the team involved in the creation of this Application can't be reached.";

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

            if (add.AddInput == 0)
            {
                Session["AV1"] = add.AddVariable;

                Session["AV2"] = add.AddAnswer;

                return View();
            }

            Session["Ainput"] = add.AddInput;

            ViewBag.AP = AP;


            ViewBag.Message = "Your Addition page.";

            return RedirectToAction("AnswerPage");
        }

        public ActionResult SubtractionPage( SubtractionQuestion sub)
        {
            Random rng = new Random();

            if (sub.SubVariable == null)
            {
                sub.SubVariable = rng.Next(1, 11);
            }

            int V1 = sub.SubVariable.Value;

            

            if (sub.SubAnswer == null)
            {
                sub.SubAnswer = rng.Next(V1 + 1, V1 + 10);
            }

            int V2 = sub.SubAnswer.Value;

            ViewBag.RNG = V2;

            ViewBag.Answer = V1;

            int SP = sub.SubSkillCounter;

            if (sub.SubInput == 0)
            {
                Session["SV1"] = sub.SubAnswer;

                Session["SV2"] = sub.SubVariable;

                return View();
            }

            Session["Sinput"] = sub.SubInput;

            ViewBag.SP = SP;


            ViewBag.Message = "Your Subtraction page.";
            return RedirectToAction("SubtractionAnswerPage");
        }

        public ActionResult AnswerPage()
        {
            int AP = 0;

            string correct = "Incorret";

            if (Session["Ainput"] != null)
            {
                if ((int)Session["AV2"] - (int)Session["AV1"] == (int)Session["Ainput"])
                {
                    correct = "Correct";

                    AP += 5;
                }
            }

            ViewBag.QA = (int)Session["Ainput"];

            ViewBag.V1 = (int)Session["AV1"];

            ViewBag.V2 = (int)Session["AV2"];

            ViewBag.correct = correct;

            ViewBag.AP = AP;

            return View();
        }

        public ActionResult SubtractionAnswerPage()
        {
            int SP = 0;

            string correct = "Incorret";


            if (Session["Sinput"] != null)
            {
                if ((int)Session["SV2"] + (int)Session["Sinput"] == (int)Session["SV1"])
                {
                    correct = "Correct";

                    SP += 5;
                }
            }


            ViewBag.QA = (int)Session["Sinput"];

            ViewBag.V1 = (int)Session["SV1"];

            ViewBag.V2 = (int)Session["SV2"];

            ViewBag.correct = correct;

            ViewBag.SP = SP;

            return View();
        }
    }
}