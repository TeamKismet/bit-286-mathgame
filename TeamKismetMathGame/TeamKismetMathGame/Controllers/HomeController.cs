﻿using System;
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

        public ActionResult AdditionPage()
        {
            AdditionQuestion add = new AdditionQuestion();

            Random rng = new Random();

            if (add.AddVariable == null)
            {
                add.AddVariable = rng.Next(1, 11);
            }

            int V1 = add.AddVariable.Value;

            ViewBag.RNG = add.AddVariable;

            if (add.AddAnswer == null)
            {
                add.AddAnswer = rng.Next(V1, V1 + 10);
            }

            int V2 = add.AddAnswer.Value;

            ViewBag.Answer = V2;

            int AP = add.AdditionSkillCounter;

            if (add.AddInput == V2 - V1)
            {
                AP += 5;
            }

            ViewBag.AP = AP;
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

            int SP = 0;

            ViewBag.SP = SP;

            if (ViewBag.QSA == VS1 - VS2)
            {
                SP += 5;
            }

            //if(add.ACorrect == true)
            //{
            //    AP += 5;
            //}


            ViewBag.Message = "Your Subtraction page.";
            return View();
        }

        public ActionResult AnswerPage()
        {
            int AP = 0;

            int V2 = ViewBag.Answer;

            int V1 = ViewBag.RNG;

            if (ViewBag.QA == V2 - V1)
            {
                AP += 5;
                return View("AnswerPage");
            }
            return View();
        }
    }
}