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
        //Main view or menu page
        public ActionResult Index()
        {
            return View();
        }

        //about pages with some minor changes from the original so it wasn't exactly like the template
        public ActionResult About()
        {
            ViewBag.Message = "Basic information about 1st Grade Simulator 2017.";

            return View();
        }

        //Changes to the contact page, but I chose not to show any actual contact info with it being live now.
        public ActionResult Contact()
        {
            ViewBag.Message = "Currently the team involved in the creation of this Application can't be reached.";

            return View();
        }

        //These are from the old placement of the teacher and student Login Pages

        //public ActionResult StudentLogin()
        //{
        //    return View();
        //}
        //public ActionResult TeacherLogin()
        //{
        //    return View();
        //}


        //This uses the class I created at the beginning of the BIT 286 for things like the addvariable, addAnswer and AddInput. I ment to do more with them, but for now they act mostly like model views
        public ActionResult AdditionPage(AdditionQuestion add)
        {
            //I start by making a random variable so the page can make random numbers I probably don't need it because there is one in the class, but at the time I was worried that 
            //   it would change variable up on me more so I just made one on the page controllers.
            Random rng = new Random();

            //I made these if statements so that the addVariables would only reload random numbers if they where null. This is a little silly looking back because suprize every time the page loads
            //   the variables are null. Any wat the addVaraible is made a random number between 1 and 10.
            if (add.AddVariable == null)
            {
                add.AddVariable = rng.Next(1, 11);
            }

            //I create V1 which stands for Variable 1 which is always the variable on the left of the equasion. I give it the addVariable's value so I can pass it to my next random number generator
            // use it as part of he range.
            int V1 = add.AddVariable.Value;

            //I am now passing that addVariable into the viewbag for RNG becuase it is a Random Number Generated Variable and the other vairable is an answer to the question but not the actual input.
            ViewBag.RNG = add.AddVariable;


            //Once again I make a check to make sure AddAnswer to make sure it isn't null. Then generate a number base off a 1 to 10 range added to the value of the first variable. this way I never 
            // get a negative number.
            if (add.AddAnswer == null)
            {
                add.AddAnswer = rng.Next(V1 + 1, V1 + 10);
            }

            //Now I add it to a Variable 2 to use in the Viewbag for the answer part of the question. 
            int V2 = add.AddAnswer.Value;

            ViewBag.Answer = V2;

            //Original I was thinking that there wold be a skill counter variable that counted would keep track of the Addition points. There would be another one for the Subtration game.
            //  Later I changed this idea so that you would have a table that kept track of the number of right and wrong answers as well as total question count and the full grade and the 
            //  artificail point system so that the children would always see a possitive variable represented in the game. However at the end of the day the database never had those changes add
            //  Without those additions I never got to add in this space to show the addition points on the question page as well as the answer page.
            int AP = add.AdditionSkillCounter;

            //I brought this further up so that the addition points can be given to the viewbag before the view return so that the AP points can be viewed on the page.
            ViewBag.AP = AP;

            //This if statement take advantage of the fact that the addInput always comes out as 0 if you don't put one in the input box. So it reads the page and initially runs through the page
            // until it hits this and uses it as a chance to fill in the question variables into the session state variables for Addition Variable 1 and 2. Then it returns the page so you can add an
            // input.
            if (add.AddInput == 0)
            {
                Session["AV1"] = add.AddVariable;

                Session["AV2"] = add.AddAnswer;

                return View();
            }

            //After the Input is different than the default and you have interacted with the page it can move passed and be passed into another Session state variable. this one for Addition Input.
            Session["Ainput"] = add.AddInput;

            ViewBag.Message = "Your Addition page.";
            
            //After all of this I redirect the page to the Answer page where it can show the results.
            return RedirectToAction("AnswerPage");
        }


        //A lot of this is very similar to the addition page so I will be more brief. I pass in the SubtractionQuestion into this action for the same reason as I added the additionQuestion.
        public ActionResult SubtractionPage(SubtractionQuestion sub)
        {
            Random rng = new Random();

            //all of the SubVariable or SubAnswer's are part of the SubtrationQuestion class which does what the additionQuesiton class does for addition but for the subtraction game
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

            //This is the first real deviation from the addition page I flip where the V2 and V1 go so they end up in the reverse positions of where they would for the addition game.
            ViewBag.RNG = V2;

            ViewBag.Answer = V1;

            int SP = sub.SubSkillCounter;

            //the view page for he SP has to be above the view return so that it can be shown on the view
            ViewBag.SP = SP;

            //Here I place the SubAnswer in Subtraction Variable 1 and SubVariable in Subtraction Variable 2 once again in there opposite position from the addition game.
            if (sub.SubInput == 0)
            {
                Session["SV1"] = sub.SubAnswer;

                Session["SV2"] = sub.SubVariable;

                return View();
            }

            Session["Sinput"] = sub.SubInput;

            ViewBag.Message = "Your Subtraction page.";

            //Here I send the question to a second answer page because prior to that the sessions variables would get mixed up.
            return RedirectToAction("SubtractionAnswerPage");
        }


        //here is where I actually answer whether the addition page was right or wrong and grade it. I recently re-added that original idea of keeping track of the question counts and right or wrong.
        //   Right now I have test variables in here, but it acutally grades acurratly based off the correct answers and the number of questions. I probably need the number of incorrect answers, but
        //   I figured it would be something that teachers would apprieciate as a clear way of seeing that without needing to proform some calculation.
        public ActionResult AnswerPage()
        {
            //I originally put the Addition points as 0 because I wanted an easy way of seeing right or wrong numarically without having to think about it for fast testing.
            int AP = 0;

            //the Q stands for Question and they are doubles to make the math round easier. It probably works with int, but when I used Decimal I had trouble so I just used double.
            double QCorrect = 956;

            double QIncorrect = 320;

            double questionCnt = 1276;

            //This is to add into the result statement that tells the student if they are right or wrong.
            string correct = "Incorret";

            //I had several situations where a null variable would lead to problems on the page so I just made it so it had to perform a check for the AddInput not being null.
            //After that it checks if the value of the Addvariable 1 subracted from AddVariable 2 is equal to the Addition input that the user put in. If it is the input is correct and
            //    it will change the string for correct to 'correct' and then it adds more test different test numbers to the Q variables and changes the AP to +5.
            if (Session["Ainput"] != null)
            {
                if ((int)Session["AV2"] - (int)Session["AV1"] == (int)Session["Ainput"])
                {
                    correct = "Correct";

                    QCorrect = 1;

                    QIncorrect = 9;

                    AP += 5;
                }
            }

            //At this point I wanted to make the grade calculation happen between the number of questions and correct answers. After some thought if I had some more time I would make the calculation
            //  for number of questions not based on a counter but a calcuation of both the right and wrong answers. Maybe later after I get the site connected to the database correctly.
            //Any way it is a double so it can round up to the nearest tenth place decimal.
            double Grade = Math.Round((QCorrect / questionCnt), 2);

            //These are all the different Math variable viewbags. I put them in to better show the data and how it works on the view. In reality I would probably not show the children the number of 
            //  incorrect and correct answers as well as the grade. I might show how many question they've answered and I would also show the number of math points they have to show the amount of
            //  progress they've made.
            ViewBag.QA = (int)Session["Ainput"];

            ViewBag.V1 = (int)Session["AV1"];

            ViewBag.V2 = (int)Session["AV2"];

            ViewBag.correct = correct;

            ViewBag.AP = AP;

            ViewBag.QC = QCorrect;

            ViewBag.QI = QIncorrect;

            ViewBag.QCnt = questionCnt;

            //THe grade is multiplied by 100 so it can be shown as a pecentage.
            ViewBag.Grade = Grade * 100;

            return View();
        }
        
        //Once again this is really the same as the first Answer page, but with some minor code changes. I will probably with more time shrink this down to some if statement in the original answer page
        //  but for now this was an quicker solution than working that through at the time.
        public ActionResult SubtractionAnswerPage()
        {
            //Just like the other answer page I create some test variables for the Q or question variables and then I make the test variables for the Subtraction Points so if the question is correct
            // the points can be added to or if it is incorrect it can be kept at the base 0.
            int SP = 0;

            double QCorrect = 2;

            double QIncorrect = 8;

            double questionCnt = 10;

            string correct = "Incorret";


            if (Session["Sinput"] != null)
            {
                //The difference between the answer page and the subtraction answer page here is that I am adding the input and the second variable to check if the answer is equal
                //  the number I am subtracting from. if it is then the question is correct and I change the test varaibles and add 5 to the Subtraction points.
                if ((int)Session["SV2"] + (int)Session["Sinput"] == (int)Session["SV1"])
                {
                    correct = "Correct";

                    QCorrect = 7;

                    QIncorrect = 3;

                    SP += 5;
                }
            }

            //Once again thsi is making the decimal grade point variable and bellow I am taking the session variables and other test variables into viewbags so they can easily be seen.
            double Grade = Math.Round((QCorrect / questionCnt), 2);

            ViewBag.QA = (int)Session["Sinput"];

            ViewBag.V1 = (int)Session["SV1"];

            ViewBag.V2 = (int)Session["SV2"];

            ViewBag.correct = correct;

            ViewBag.SP = SP;

            ViewBag.QC = QCorrect;

            ViewBag.QI = QIncorrect;

            ViewBag.QCnt = questionCnt;

            ViewBag.Grade = Grade * 100;

            return View();
        }
    }
}